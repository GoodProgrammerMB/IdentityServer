using System;
using GP.IdentityServer.Helpers;
using Microsoft.AspNetCore.Identity;

namespace GP.IdentityServer.Infrastructure.EF.Models
{
    public class User : IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string DataEventRecordsRole { get; set; }
        public string SecuredFilesRole { get; set; }
        public string PasswordSalt { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordTokenExpiration { get; set; }

        public void SetPassword(string password)
        {
            PasswordSalt = PasswordHelper.GenerateSalt();
            PasswordHash = PasswordHelper.HashPassword(password, PasswordSalt);
        }

        public bool ValidatePassword(string password)
        {
            return PasswordHelper.HashPassword(password, PasswordSalt) == PasswordHash;
        }
    }
}
