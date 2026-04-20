using Microsoft.EntityFrameworkCore;

namespace Labb3_API.models
{
    public class PersonInterestsDbContext : DbContext
    {
        public PersonInterestsDbContext(DbContextOptions<PersonInterestsDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

    }
}
