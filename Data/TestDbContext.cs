
using Microsoft.EntityFrameworkCore;

namespace CodeSample.Data
{
    public class TestDbContext : DbContext
    {


        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thing>().HasData(
                    new Thing
                    {
                        Id = 1,
                        Name = "Test1"
                    },
                     new Thing
                     {
                         Id = 2,
                         Name = "Test2"
                     }
           );

        }

        public DbSet<Thing> Things { get; set; } = default!;
    }
}