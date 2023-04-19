using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZAD_REK.Services;

namespace ZAD_REK.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{IdProduct}")]
        public async Task<IActionResult> GetProduct([FromRoute]int IdProduct)
        {
           try
            {
                return Ok(await _service.GetProduct(IdProduct));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetProducts());
        }


        [HttpDelete("{IdProduct}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int IdProduct)
        {
            try
            {
                await _service.DeleteProduct(IdProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
