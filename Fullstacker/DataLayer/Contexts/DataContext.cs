using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }
    }
}