using CosmosDbEF.Model;
using Microsoft.EntityFrameworkCore;
namespace CosmosDbEF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }
        public DbSet<Order> Order { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(p =>
            {
                p.ToContainer("Order");
                p.HasPartitionKey(x => x.FirstName);
                p.HasPartitionKey(o => o.LastName);
                p.HasPartitionKey(p => p.Age);
                p.HasPartitionKey(t => t.Email);
            });
        }
    }
}
