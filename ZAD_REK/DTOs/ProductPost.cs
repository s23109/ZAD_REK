

using System.ComponentModel.DataAnnotations;

namespace ZAD_REK.DTOs
{
    public class ProductPost
    {
        //Post = Create 
        [Required(ErrorMessage = "Pole ProductName jest wymagane")]
        [MaxLength(120, ErrorMessage = "Pole powinno mieć maksymalnie 120 znaków")]
        public string ProductName { get; set; }
        public string? ProductDesc { get; set; }

        [Required(ErrorMessage = "Pole Price jest wymagane")]
        [Range(1,int.MaxValue , ErrorMessage ="Pole Price musi mieć dodatnią wartość")]
        public Double Price { get; set; }

    }
}
