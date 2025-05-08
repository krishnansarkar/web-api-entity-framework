using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Models.Entities;

namespace ProductInventoryAPI.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }
        public DbSet<Product> Products { get; set; }
    }
}
