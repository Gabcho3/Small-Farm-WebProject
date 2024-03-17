using System.ComponentModel.DataAnnotations;

namespace SmallFarm.Core.Models.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        //Available Quantity
        public double Quantity { get; set; }

        //Price Per Kilogram
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Manufacturer { get; set; }
    }
}
