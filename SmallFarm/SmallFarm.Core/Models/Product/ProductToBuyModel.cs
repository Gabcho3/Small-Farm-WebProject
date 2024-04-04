using Microsoft.EntityFrameworkCore;

namespace SmallFarm.Core.Models.Product
{
    public class ProductToBuyModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string? Description { get; set; } = null!;

        [Precision(10, 2)]
        public double AvailableQuantity { get; set; }

        [Precision(18, 2)]
        public decimal PricePerKg { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public double Quantity { get; set; }

        public bool IsActive { get; set; }

        public decimal Total  => Math.Round((decimal)Quantity * PricePerKg, 2);
    }
}
