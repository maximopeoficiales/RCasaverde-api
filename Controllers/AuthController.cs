using backend.Models;
using Microsoft.AspNetCore.Mvc;
using backend.Config;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Principal;
using System;

namespace backend.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthManager jwtAuthManager;

        public AuthController(IJwtAuthManager authManager,
                              IConfiguration Configuration)
        {
            this.jwtAuthManager = authManager;
        }

        [HttpPost("user")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> userLogin([FromBodyAttribute] UserCred user)
        {
            UserAuthResponse result = await this.jwtAuthManager.AuthenticateUserAsync(user.username, user.password);
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
            StaffAuthResponse result = await this.jwtAuthManager.AuthenticateStaffAsync(staff.username, staff.password);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> validateJWT([FromQuery] string token)
        {
            return await Task.Run(() => Ok(jwtAuthManager.isTokenValidAsync(token)));
        }

        [HttpPost("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> logout([FromQuery] string jwt) 
        {
            return await Task.Run(() => Ok());  
        }

    }
}
