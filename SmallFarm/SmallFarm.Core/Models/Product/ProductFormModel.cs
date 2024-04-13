using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SmallFarm.Core.Models.ProductCategory;
using static SmallFarm.Common.DataConstants.ProductConstants;
using static SmallFarm.Common.ValidationErrors.GeneralValidationErrors;

namespace SmallFarm.Core.Models.Product
{
    public class ProductFormModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthValidationError)]
        public string Name { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = StringMaxLengthValidationError)]
        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        public decimal Quantity { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        public decimal PricePerKg { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<ProductCategoryViewModel> ProductCategories { get; set; } = new List<ProductCategoryViewModel>();

        [Required]
        public Guid ManufacturerId { get; set; }
    }
}
