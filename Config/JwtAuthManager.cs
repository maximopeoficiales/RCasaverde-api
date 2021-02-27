using backend.Models;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;
using backend.Config;
using System.Threading.Tasks;

namespace dotnet_core_api.Config
{

    public class JwtAuthManager : IJwtAuthManager
    {
        private dbContext db = new dbContext();
        private Encription bcrypt = new Encription();
        private readonly string key;

        public JwtAuthManager(string key)
        {
            this.key = key;
        }

        public async Task<UserAuthResponse> AuthenticateUser(string username, string password)
        {
            User user = await this.db.Users.AsNoTracking().Where(e => e.Username == username).FirstOrDefaultAsync();

            if (user == null || user.Active == 0)
            {
                return null;
            }

            if (bcrypt.verifyPassword(password, user.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                    Expires = DateTime.UtcNow.AddHours(0),
                    SigningCredentials =
                        new SigningCredentials(
                                new SymmetricSecurityKey(tokenKey),
                                SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.role = this.db.Roles.Find(user.IdRole);
                return new UserAuthResponse { jwt = tokenHandler.WriteToken(token), user = user };
            }
            else
            {
                return null;
            }
        }

        public async Task<StaffAuthResponse> AuthenticateStaff(string username, string password)
        {
            Staff user = await this.db.Staff.AsNoTracking().Where(e => e.Username == username).FirstOrDefaultAsync();

            if (user == null || user.Active == 0)
            {
                return null;
            }

            if (bcrypt.verifyPassword(password, user.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                    Expires = DateTime.UtcNow.AddHours(0),
                    SigningCredentials =
                        new SigningCredentials(
                                new SymmetricSecurityKey(tokenKey),
                                SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.role = this.db.Roles.Find(user.IdRole);
                return new StaffAuthResponse { jwt = tokenHandler.WriteToken(token), user = user };
            }
            else
            {
                return null;
            }
        }
    }

}
