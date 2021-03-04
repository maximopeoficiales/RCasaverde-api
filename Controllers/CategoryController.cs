using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{

    [Authorize]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private dbContext db = new dbContext();

        [AllowAnonymous]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Category>>> findAll()
        {
            List<Category> categories = await this.db.Categories.ToListAsync();

            if (categories.Count < 1)
            {
                return NotFound();
            }
            else
            {
                return Ok(categories);
            }
        }

    }

}
