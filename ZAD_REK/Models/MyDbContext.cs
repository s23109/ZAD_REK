using Microsoft.EntityFrameworkCore;

namespace ZAD_REK.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public MyDbContext()
        {

        }

      

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("Products");

                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(120);

                entity.Property(e => e.CreatedAt).IsRequired();

                entity.Property(e => e.EditedAt).IsRequired();

                entity.Property(e => e.ProductDesc);

                entity.Property(e => e.Price).IsRequired();

            });
        }
    }
}
