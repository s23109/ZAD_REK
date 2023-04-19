using Microsoft.AspNetCore.Mvc;
using ZAD_REK.DTOs;
using ZAD_REK.Services;

namespace ZAD_REK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] AccountDTO account)
        {
            try
            {
                await _service.RegisterAsync(account);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser ([FromForm] AccountDTO account)
        {
            try
            {
               var dto = await _service.Login(account);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateAccessToken")]
        public async Task<IActionResult> UpdateAccessToken (string refreshToken)
        {
            try
            {
                var dto = await _service.UpdateToken(refreshToken);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
