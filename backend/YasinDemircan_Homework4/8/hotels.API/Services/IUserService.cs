using System;
using System.Threading.Tasks;
using hotels.API.Models;

namespace hotels.API.Services
{
    public interface IUserService
    {
        Task<UserInfo> Authenticate(TokenRequest req);
    }
}
