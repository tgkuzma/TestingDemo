using System.Data.Entity;
using Models;

namespace Data
{
    public class TestingContext : DbContext
    {
        public TestingContext() : base("Testing.DbConnection")
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}