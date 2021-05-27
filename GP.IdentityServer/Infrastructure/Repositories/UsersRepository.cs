using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.IdentityServer.Infrastructure.EF;
using GP.IdentityServer.Infrastructure.EF.Models;
using GP.IdentityServer.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GP.IdentityServer.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Get(string id)
        {
            var model = await _context.Users
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync();

            return model;
        }

        public async Task<User> GetByUserName(string username)
        {
            var model = await _context.Users
                .Where(u => u.UserName == username)
                .SingleOrDefaultAsync();

            return model;
        }

        public async Task<User> Add(User user)
        {
            var model = new User();
            model.UserName = user.UserName;
            //model.Password = user.Password;
            model.Email = user.Email;
            model.PasswordSalt = user.PasswordSalt;
            model.IsAdmin = user.IsAdmin;
            

            _context.Users.Add(model);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users
                .Select(u => u)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> Users()
        {
            return await _context.Users
                .Select(u => u)
                .ToListAsync();
        }

        public async Task<User> User(string id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Select(x => x)
                .SingleOrDefaultAsync();
        }

        public async Task Delete(string id)
        {
            var user = await _context.Users.FindAsync(Convert.ToInt32(id));

            if (user == null)
                throw new Exception($"User with id={id} not found");

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            var entity = await _context.Users

                .SingleOrDefaultAsync(u => u.Id == user.Id);

            var existing = await _context.Users
                .SingleOrDefaultAsync(u => u.UserName == user.UserName && u.Id != user.Id);

            if (existing != null)
                throw new InvalidOperationException("Username already exists");

            entity.UserName = user.UserName;
            entity.Email = user.Email;

           // entity.Password = user.Password;
            entity.PasswordSalt = user.PasswordSalt;
            entity.IsAdmin = user.IsAdmin;
            entity.ResetPasswordToken = user.ResetPasswordToken;
            entity.ResetPasswordTokenExpiration = user.ResetPasswordTokenExpiration;

           

            await _context.SaveChangesAsync();
        }

        public async Task DeleteByUserName(string username)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.UserName == username);

            if (user == null)
                throw new Exception($"User with id={username} not found");

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
