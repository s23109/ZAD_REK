namespace ZAD_REK.DTOs
{
    public class ProductDTO
    {
        // w przypadku powiązań z innymi obiektami , tutaj nie będą typy ,,virtual'' a np zwykłe listy / id obiektu 
        public int IdProduct { get; set; }

        public string ProductName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }

        public string? ProductDesc { get; set; }

        public Double Price { get; set; }

    }
}
