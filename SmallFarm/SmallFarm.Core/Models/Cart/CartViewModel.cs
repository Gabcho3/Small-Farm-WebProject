using System.ComponentModel.DataAnnotations;

namespace SmallFarm.Core.Models.Cart
{
    public class CartViewModel
    {
        public Guid ProductId { get; set; }

        public string UserId { get; set; }

        [Range(0, 1000, ErrorMessage = "{0} must be between {1} and {2} kilograms")]
        public double Quantity { get; set; }

        public decimal Total { get; set; }
    }
}
