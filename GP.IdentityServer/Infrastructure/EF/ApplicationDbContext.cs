using GP.IdentityServer.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace GP.IdentityServer.Infrastructure.EF
{
    public class ApplicationDbContext : DbContext
    {
        internal DbSet<User>Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
