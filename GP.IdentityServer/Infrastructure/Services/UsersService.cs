using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GP.IdentityServer.Infrastructure.DTO;
using GP.IdentityServer.Infrastructure.EF.Mappers;
using GP.IdentityServer.Infrastructure.EF.Models;
using GP.IdentityServer.Infrastructure.Interfaces;
using IdentityModel;

namespace GP.IdentityServer.Services
{
    public class UsersService: IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        public async Task<UserDto> ValidateUserAsync(string username, string password)
        {
            var user = await _usersRepository.Get(username);

            if (user == null)
                return null;

            return user.ValidatePassword(password) ? user.ToDto() : null;
        }

        public async Task<bool> ValidateUserExistsAsync(string userId)
        {
            var user = await _usersRepository.Get(userId);

            return user != null;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _usersRepository.GetUsers();

            return users.Select(x=>x.ToDto());
        }

        public async Task<UserDto> GetUser(string id)
        {
            var user = await _usersRepository.Get(id);

            return user.ToDto();
        }

        public async Task<UserDto> GetByUserName(string username)
        {
            var user = await _usersRepository.GetByUserName(username);

            return user.ToDto();
        }

        public async Task<UserDto> GetUserByToken(string token)
        {
            var users = await _usersRepository.GetUsers();
            var user = users.SingleOrDefault(u => u.ResetPasswordToken == token && u.ResetPasswordTokenExpiration > DateTime.UtcNow);

            return user.ToDto();
        }

        public async Task UpdateUser(UserDto user)
        {
            await _usersRepository.Update(user.ToDomainObject());
        }

        public async Task<string> GetResetPasswordToken(UserDto user)
        {
            user.ResetPasswordToken = Guid.NewGuid().ToString();
            user.ResetPasswordTokenExpiration = DateTime.UtcNow.AddHours(2);

            await _usersRepository.Update(user.ToDomainObject());

            return user.ResetPasswordToken;
        }

        public async Task DeleteUser(string id)
        {
            await _usersRepository.Delete(id);
        }
        public async Task DeleteByUserName(string username)
        {
            await _usersRepository.Delete(username);
        }

        public async Task<string> AddUser(UserDto user)
        {
            var added = await _usersRepository.Add(user.ToDomainObject());

            user.Id = added.Id;
            return added.Id;
        }

        /// <summary>
        /// Automatically provisions a user.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claims">The claims.</param>
        /// <returns></returns>
        public User AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            // create a list of claims that we want to transfer into our store
            var filtered = new List<Claim>();

            foreach (var claim in claims)
            {
                // if the external system sends a display name - translate that to the standard OIDC name claim
                if (claim.Type == ClaimTypes.Name)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, claim.Value));
                }
                // if the JWT handler has an outbound mapping to an OIDC claim use that
                else if (JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.ContainsKey(claim.Type))
                {
                    filtered.Add(new Claim(JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap[claim.Type], claim.Value));
                }
                // copy the claim as-is
                else
                {
                    filtered.Add(claim);
                }
            }

            // if no display name was provided, try to construct by first and/or last name
            if (filtered.All(x => x.Type != JwtClaimTypes.Name))
            {
                var first = filtered.FirstOrDefault(x => x.Type == JwtClaimTypes.GivenName)?.Value;
                var last = filtered.FirstOrDefault(x => x.Type == JwtClaimTypes.FamilyName)?.Value;
                if (first != null && last != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first + " " + last));
                }
                else if (first != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first));
                }
                else if (last != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, last));
                }
            }

            // create a new unique subject id
            var sub = CryptoRandom.CreateUniqueId(format: CryptoRandom.OutputFormat.Hex);

            // check if a display name is available, otherwise fallback to subject id
            var name = filtered.FirstOrDefault(c => c.Type == JwtClaimTypes.Name)?.Value ?? sub;

            // create new user
            var user = new User
            {
               
            };

            // add user to in-memory store
           // _users.Add(user);

            return user;
        }
    }
}
