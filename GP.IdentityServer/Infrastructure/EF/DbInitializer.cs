using System.Linq;
using GP.IdentityServer.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace GP.IdentityServer.Infrastructure.EF
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            var users = new User[]
            {
                new User() {Email = "",IsAdmin = true, UserName = "adminTest"
                    //Username = "alice",
                   // Password = "alice",
                    //Claims =
                    //{
                    //    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    //    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    //    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    //    new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                    //    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    //    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                    //   // new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    //}
                }
                
            };
            foreach (var u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();
        }
    }
}
