using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using backend.Config;
using System;

namespace backend.Controllers
{
    [Route("api/public")]
    [ApiController]
    [AllowAnonymous]
    public class PublicController : ControllerBase
    {
        private dbContext db = new dbContext();
        private Encription bcrypt = new Encription();

        [HttpPost("signup")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> signup([FromBody] User user)
        {
            try
            {
                user.Password = bcrypt.hashPassword(user.Password);
                await this.db.Users.AddAsync(user);
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateException err)
            {
                Console.WriteLine(err.InnerException.Message);
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

            user.role = this.db.Roles.Find(user.IdRole);
            return Ok(user);
        }

    }

}
