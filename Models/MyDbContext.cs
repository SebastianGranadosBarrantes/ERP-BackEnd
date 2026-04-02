using Microsoft.EntityFrameworkCore;

namespace MyApi.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Workers> Workers { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Departments> Departments { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<ProductXOrder> ProductXOrders { get; set; }

        public DbSet<Rols> Rols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductXOrder>()
                .HasKey(po => new { po.IdOrder, po.IdProduct });
        }

    }

}
