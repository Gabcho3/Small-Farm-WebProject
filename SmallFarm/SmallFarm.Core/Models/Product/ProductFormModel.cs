using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static SmallFarm.Common.DataConstants.ProductConstants;
using static SmallFarm.Common.ValidationErrors.GeneralValidationErrors;

namespace SmallFarm.Core.Models.Product
{
    public class ProductFormModel
    {

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthValidationError)]
        public string? Name { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = StringMaxLengthValidationError)]
        public string? Description { get; set; }

        [Required]
        [Range(0.1, 50.0)]
        public double Quantity { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(0.10, 1000)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public Guid ManufacturerId { get; set; }
    }
}
