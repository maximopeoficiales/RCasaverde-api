using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/public")]
    [ApiController]
    [AllowAnonymous]
    public class PublicController : ControllerBase
    {
        private dbContext db = new dbContext();

        [HttpPost("signup")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> signup([FromBody] User user)
        {
            EntityEntry<User> u = await this.db.Users.AddAsync(user);
            try
            {
                if (u.State == EntityState.Added)
                {
                    await this.db.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                User existentUser = await this.db.Users.Where(u =>
                    u.Phone == user.Phone ||
                    u.Email == user.Email ||
                    u.Username == user.Username
                ).FirstOrDefaultAsync();

                if (existentUser.Username == user.Username)
                {
                    return BadRequest("Ese nombre de usuario ya esta registrado.");
                }
                else if (existentUser.Phone == user.Phone)
                {
                    return BadRequest("Ese número de teléfono ya esta registrado.");
                }
                else if (existentUser.Email == user.Email)
                {
                    return BadRequest("Ese correo ya esta registrado.");
                }
                else
                {
                    return BadRequest("Información enviada incorrecta, revisar.");
                }
            }

            u.Entity.role = this.db.Roles.Find(user.IdRole);
            return u.Entity;
        }

    }

}
