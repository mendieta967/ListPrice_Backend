using Lista_Price.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lista_Price.Data
{
    public class AplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }
    }
}
