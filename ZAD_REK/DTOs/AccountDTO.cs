using System.ComponentModel.DataAnnotations;

namespace ZAD_REK.DTOs
{
    public class AccountDTO
    {
        [Required]
        [MaxLength(32, ErrorMessage ="Login może mieć co najwyżej 32 znaki")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
