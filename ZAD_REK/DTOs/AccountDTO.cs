using System.ComponentModel.DataAnnotations;

namespace ZAD_REK.DTOs
{
    public class AccountDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
