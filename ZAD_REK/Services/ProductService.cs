using Microsoft.EntityFrameworkCore;
using ZAD_REK.DTOs;
using ZAD_REK.Models;

namespace ZAD_REK.Services
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;

        public ProductService(MyDbContext context)
        {
            _context = context;
        }


        public async Task<Product> GetProduct(int IdProduct)
        {
            
            var products =  _context.Products.Where(e => e.IdProduct == IdProduct);

            if (!products.Any())
            {
                throw new Exception("Brak produktu o podanym ID");
            }

            return (Product)products.First();

           
          
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }


        public async Task DeleteProduct(int IdProduct)
        {
            var products = _context.Products.Where(e => e.IdProduct == IdProduct);

            if (!products.Any())
            {
                throw new Exception("Brak produktu o podanym ID");
            }

            _context.Products.Remove(await products.FirstAsync());
            _context.SaveChangesAsync();

        }

        public async Task CreateProduct(ProductPost post)
        {
            try
            {
                _context.Products.Add(new Product
                {
                    ProductName = post.ProductName,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    ProductDesc = post.ProductDesc,
                    Price = post.Price
                });
                _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateProduct(int idProduct, ProductPost put)
        {
            var products = _context.Products.Where(e => e.IdProduct == idProduct);

            if (!products.Any())
            {
                throw new Exception("Brak produktu o podanym ID");
            }

            _context.Products.Where(e => e.IdProduct == idProduct).ToList().ForEach(product => {
                product.ProductName = put.ProductName;
                product.EditedAt = DateTime.Now;
                product.ProductDesc = put.ProductDesc;  
                product.Price = put.Price;
            
            });

            _context.SaveChangesAsync();
        }
    }
}
