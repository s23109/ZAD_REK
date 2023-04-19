using Microsoft.EntityFrameworkCore;
using ZAD_REK.DTOs;
using ZAD_REK.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ZAD_REK.Services
{
    public class AccountService : IAccountService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountService(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task RegisterAsync(AccountDTO account)
        {
            var userExists = await _context.Accounts.AnyAsync(e => e.Login.Equals(account.Login));

            if (userExists)
            {
                throw new Exception("Login jest już używany");
            }

            var hashedPass = GenerateHashedAndSaltedPass(account.Password);

            var newAccount = new Account
            {
                Login = account.Login,
                Password = hashedPass.Item1,
                Salt = hashedPass.Item2,
                RefreshToken = GenerateRefreshToken(),
                RefrestTokenExp = DateTime.Now.AddHours(12)
            };

            await _context.Accounts.AddAsync(newAccount);
            await _context.SaveChangesAsync();

        }

        public async Task<TokenDTO> Login(AccountDTO account)
        {
            var userLogging = await _context.Accounts.FirstOrDefaultAsync(e => e.Login.Equals(account.Login));

            if (userLogging == null)
            {
                throw new Exception("Zły Login lub hasło");
            }

            if (userLogging.Password != GetHashedSaltedPassword(account.Password, userLogging.Salt))
            {
                throw new Exception("Zły login lub Hasło");
            }

            var opt = GetJwtSecurityToken();

            userLogging.RefreshToken = GenerateRefreshToken();
            userLogging.RefrestTokenExp= DateTime.Now.AddHours(12);

            await _context.SaveChangesAsync();

            return new TokenDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(opt).ToString(),
                RefreshToken = userLogging.RefreshToken
            };

        }

        public async Task<TokenDTO> UpdateToken(string refreshToken)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken);
            
            if (user == null)
            {
                throw new Exception("Nieznaleziono użytkownika");
            }

            if (user.RefrestTokenExp< DateTime.Now)
            {
                throw new Exception("RefreshToken wygasł");
            }

            var token = GetJwtSecurityToken();

            user.RefreshToken = GenerateRefreshToken();
            user.RefrestTokenExp = DateTime.Now.AddHours(12);

            await _context.SaveChangesAsync();

            return new TokenDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token).ToString(),
                RefreshToken = user.RefreshToken
            };

        }


        public Tuple<string,string> GenerateHashedAndSaltedPass (string pass)
        {
            byte[] saltBytes = new byte[128/8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(saltBytes);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256/8
                ));


            string salt = Convert.ToBase64String(saltBytes);

            return new(hashed, salt);

        }


        public string GenerateRefreshToken()
        {
            var refreshToken = "";

            using (var genNum = RandomNumberGenerator.Create())
            {
                var r = new byte[1024];
                genNum.GetBytes(r);
                refreshToken = Convert.ToBase64String(r); 
            }

            return refreshToken;
        }


        public string GetHashedSaltedPassword( string pass , string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            string hashedSalted = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password : pass,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));

            return hashedSalted;
        }

        public JwtSecurityToken GetJwtSecurityToken()
        {
            var claims = new Claim[]
            {
                new (ClaimTypes.Role, "user")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["PassSecret"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("https://localhost:7282", "https://localhost:7282", claims, 
                expires: DateTime.UtcNow.AddMinutes(5), signingCredentials: creds);

            return token;
        }

    }
}
