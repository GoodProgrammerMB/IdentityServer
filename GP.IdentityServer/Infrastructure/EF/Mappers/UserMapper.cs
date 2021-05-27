using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.IdentityServer.Infrastructure.DTO;
using GP.IdentityServer.Infrastructure.EF.Models;

namespace GP.IdentityServer.Infrastructure.EF.Mappers
{
    internal static class UserMapper
    {
        public static IEnumerable<User> ToDomainObjectCollection(this IEnumerable<UserDto> array)
        {
            return array.ToList().Select(x => x.ToDomainObject()).ToList();
        }

        public static User ToDomainObject(this UserDto e)
        {
            return new User()
            {
                UserName = e.UserName,
                Email = e.Email,
                IsAdmin = e.IsAdmin
            };
        }

        public static UserDto ToDto(this User e) =>
            new UserDto()
            {
                Email = e.Email,
                UserName = e.UserName,
                Id = e.Id,
                IsAdmin = e.IsAdmin,
                ResetPasswordTokenExpiration = e.ResetPasswordTokenExpiration,
                ResetPasswordToken = e.ResetPasswordToken
            };
    }
}
