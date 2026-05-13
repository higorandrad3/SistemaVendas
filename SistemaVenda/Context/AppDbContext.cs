using Microsoft.EntityFrameworkCore;
using SistemaVenda.Models;

namespace SistemaVenda.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
