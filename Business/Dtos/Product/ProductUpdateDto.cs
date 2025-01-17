using Core.Constants.Enums;

namespace Business.Dtos.Product
{
    public class ProductUpdateDto
    {
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Photo { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public ProductType Type { get; set; }
    }
}
