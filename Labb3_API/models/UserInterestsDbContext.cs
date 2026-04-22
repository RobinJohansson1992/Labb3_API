using Microsoft.EntityFrameworkCore;

namespace Labb3_API.models
{
    public class UserInterestsDbContext : DbContext
    {
        public UserInterestsDbContext(DbContextOptions<UserInterestsDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

    }
}
