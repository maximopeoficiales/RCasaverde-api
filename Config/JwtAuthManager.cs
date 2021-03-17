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
using Microsoft.Extensions.Configuration;
using System.Security.Principal;

namespace backend.Config
{

    public class JwtAuthManager : IJwtAuthManager
    {
        private dbContext db = new dbContext();
        private Encription bcrypt = new Encription();
        private readonly string key;
        private readonly IConfiguration configuration;

        public JwtAuthManager(IConfiguration Configuration)
        {
            configuration = Configuration;
            key = configuration.GetValue<string>("jwt-secret");
        }

        public async Task<UserAuthResponse> AuthenticateUserAsync(string username, string password)
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

        public async Task<StaffAuthResponse> AuthenticateStaffAsync(string username, string password)
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

        public async Task<bool> isTokenValidAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            // Si el tiempo actual es mayor a el tiempo de expiración del token
            if (principal.Identity.IsAuthenticated)
            {
                return await Task.Run(() => true);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "any",
                ValidAudience = "any",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<string>("jwt-secret"))) // The same key as the one that generate the token
            };
        }

        public Task invalidateTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);
        }
    }
}
