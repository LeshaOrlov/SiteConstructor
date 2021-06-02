using Microsoft.EntityFrameworkCore;

namespace SiteConstructor.WebApp.Models
{
    public class TestContext: DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<TestEntity2> TestEntities2 { get; set; }

        public DbSet<TestEntity2> TestEntities3 { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            //Database.EnsureDeleted();   
            Database.EnsureCreated();   
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;");
        //}

        
    }
}
