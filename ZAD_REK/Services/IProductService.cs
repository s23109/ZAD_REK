using ZAD_REK.DTOs;
using ZAD_REK.Models;

namespace ZAD_REK.Services
{
    public interface IProductService
    {

        Task<Product> GetProduct(int IdProduct);

        Task<IEnumerable<Product>> GetProducts();



    }
}
