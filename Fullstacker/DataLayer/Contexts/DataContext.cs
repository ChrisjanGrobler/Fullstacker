using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace DataLayer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
    }
}