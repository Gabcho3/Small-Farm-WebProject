using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Models.Cart;

namespace SmallFarm.Core.Models.Product
{
    public class ProductToBuyModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [Range(0.1, 1000, ErrorMessage = "{0} must be between {1} and {2} kilograms")]
        [Precision(10, 2)]
        public double AvailableQuantity { get; set; }

        [Precision(18, 2)]
        public decimal? PricePerKg { get; set; }

        public string? ImageUrl { get; set; }

        public string? Manufacturer { get; set; }

        public CartViewModel Cart { get; set; } = new CartViewModel();
    }
}
