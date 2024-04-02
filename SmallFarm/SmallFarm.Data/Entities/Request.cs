using System.ComponentModel.DataAnnotations;
using static SmallFarm.Common.DataConstants.ManufacturerConstants;

namespace SmallFarm.Data.Entities
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string ManufacturerName { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        [Required]
        public string ManufacturerDescription { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string ManufacturerPhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string ManufacturerAddress { get; set; } = null!;

        [Required]
        public int CityId { get; set; }

        public City City { get; set; } = null!;

        public bool IsActive { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
    }
}
