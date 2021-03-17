using System.Threading.Tasks;
using backend.Models;

namespace backend.Config
{

    public interface IJwtAuthManager
    {
        Task<UserAuthResponse> AuthenticateUserAsync(string username, string password);
        Task<StaffAuthResponse> AuthenticateStaffAsync(string username, string password);
        Task<bool> isTokenValidAsync(string token);
        Task invalidateTokenAsync(string token);
    }

}
