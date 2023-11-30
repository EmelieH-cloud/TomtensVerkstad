using Microsoft.EntityFrameworkCore;
using TomtensVerkstad.Models;

namespace TomtensVerkstad.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Sätter precisionen som ska gälla för decimaler. 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasPrecision(18, 2);

            // ======== D A T A S E E D I N G =====================================

            // När vi seed:ar data måste vi ange id, dvs detta sköts inte automatiskt. 
            //  Utan m-suffixet så skulle siffran automatiskt uppfattas som en
            //  double och inte en decimal.

            modelBuilder.Entity<Product>().HasData(
           new { ProductId = 1, Name = "Chinese Money Plant", Price = 10.99m },
           new { ProductId = 2, Name = "Aloe Vera", Price = 10.99m },
           new { ProductId = 3, Name = "Jade Plant", Price = 10.99m },
           new { ProductId = 4, Name = "Snake Plant", Price = 10.99m },
           new { ProductId = 5, Name = "Green Ivy", Price = 20.99m }
              );


        }

        // OnConfiguring, connection string. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Kommer skapas en databas på servern med detta namnet.
            optionsBuilder.UseSqlServer("Server=USER-PC\\SQLEXPRESS;Database=JulverkstadDb;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=True;");
        }
    }
}
