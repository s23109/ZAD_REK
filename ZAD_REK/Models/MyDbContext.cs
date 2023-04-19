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
            var products = new List<Product> {
                new Product
                {
                    ProductName= "Prod1",
                    CreatedAt = DateTime.Now,
                    EditedAt= DateTime.Now,
                    ProductDesc= "Desc1",
                    Price = 1111
                },

                new Product
                {
                    ProductName = "Prod2",
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    ProductDesc = null,
                    Price = 2222
                },
                new Product
                {
                    ProductName = "Prod3",
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    ProductDesc = "Desc3",
                    Price = 3333
                }
                };

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(120);

                entity.Property(e => e.CreatedAt).IsRequired();

                entity.Property(e => e.EditedAt).IsRequired();

                entity.Property(e => e.ProductDesc);

                entity.Property(e => e.Price).IsRequired();

                entity.HasData(products);

                entity.ToTable("Products");

            });

            

        }
    }
}
