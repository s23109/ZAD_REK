namespace ZAD_REK.Models
{
    public class Product
    {
        
        public int IdProduct { get; set; }

        public string ProductName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }

        public string? ProductDesc { get; set; }

        public Double Price { get; set; }

    }
}
