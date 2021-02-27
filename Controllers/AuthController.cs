using backend.Models;
using Microsoft.AspNetCore.Mvc;
using backend.Config;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace backend.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthManager jwtAuthManager;

        public AuthController(IJwtAuthManager authManager)
        {
            this.jwtAuthManager = authManager;
        }

        [HttpPost("user")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> userLogin([FromBodyAttribute] UserCred user)
        {
            UserAuthResponse result = await this.jwtAuthManager.AuthenticateUser(user.username, user.password);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("staff")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> staffLogin([FromBodyAttribute] UserCred staff)
        {
            StaffAuthResponse result = await this.jwtAuthManager.AuthenticateStaff(staff.username, staff.password);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
