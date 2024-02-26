using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmallFarm.Common.DataConstants.ProductConstants;

namespace SmallFarm.Data.Entities
{
    public class Product
    {
        public Product()
        {
            Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public byte[]? Image { get; set; }

        [Required]
        public Guid ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;
    }
}
