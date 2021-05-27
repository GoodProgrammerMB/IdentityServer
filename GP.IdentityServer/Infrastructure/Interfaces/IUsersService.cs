using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.IdentityServer.Infrastructure.DTO;

namespace GP.IdentityServer.Infrastructure.Interfaces
{
    public interface IUsersService
    {
        Task<UserDto> ValidateUserAsync(string username, string password);
        Task<bool> ValidateUserExistsAsync(string userId);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<string> AddUser(UserDto user);
        Task DeleteUser(string id);
        Task DeleteByUserName(string username);
        Task<UserDto> GetUser(string id);
        Task<UserDto> GetByUserName(string username);
        Task<UserDto> GetUserByToken(string token);
        Task UpdateUser(UserDto user);
        Task<string> GetResetPasswordToken(UserDto user);
    }
}
