using System.ComponentModel.DataAnnotations;
using static SmallFarm.Common.DataConstants.LocationConstants;

namespace SmallFarm.Data.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength)]
        public string City { get; set; } = null!;
    }
}
