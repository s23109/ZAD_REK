using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZAD_REK.DTOs;
using ZAD_REK.Services;

namespace ZAD_REK.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> CreateProduct (ProductPost product)
        {

            try { 
            await _service.CreateProduct(product);
            return Created("",product);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{IdProduct}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]int IdProduct, ProductPost product)
        {
            try
            {
                await _service.UpdateProduct(IdProduct, product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
