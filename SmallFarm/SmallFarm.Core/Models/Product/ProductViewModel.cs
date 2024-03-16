namespace SmallFarm.Core.Models.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Manufacturer { get; set; }
    }
}
