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
    }
}
