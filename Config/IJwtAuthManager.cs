using System.Threading.Tasks;
using backend.Models;

namespace backend.Config
{

    public interface IJwtAuthManager
    {
        Task<UserAuthResponse> AuthenticateUser(string username, string password);
        Task<StaffAuthResponse> AuthenticateStaff(string username, string password);
    }

}
