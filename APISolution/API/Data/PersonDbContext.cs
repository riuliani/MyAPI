using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {

        }
    }
}
