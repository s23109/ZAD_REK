using ZAD_REK.DTOs;

namespace ZAD_REK.Services
{
    public interface IAccountService
    {
        Task RegisterAsync(AccountDTO account);

        Task<TokenDTO> Login (AccountDTO account);

        Task<TokenDTO> UpdateToken(string refreshToken);

    }
}
