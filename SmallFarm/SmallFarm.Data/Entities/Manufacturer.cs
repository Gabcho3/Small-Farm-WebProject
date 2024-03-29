﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmallFarm.Common.DataConstants.ManufacturerConstants;

namespace SmallFarm.Data.Entities
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Id = Guid.NewGuid();
            Products = new List<Product>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; } = null!;

        public List<Product> Products { get; set; }
    }
}
