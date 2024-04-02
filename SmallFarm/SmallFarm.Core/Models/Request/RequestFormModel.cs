using SmallFarm.Core.Models.City;
using System.ComponentModel.DataAnnotations;
using static SmallFarm.Common.DataConstants.ManufacturerConstants;
using static SmallFarm.Common.ValidationErrors.GeneralValidationErrors;

namespace SmallFarm.Core.Models.Request
{
    public class RequestFormModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthValidationError)]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLengthValidationError)]
        [Display(Name = "Manufacturer Description")]
        public string ManufacturerDescription { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, ErrorMessage = StringMaxLengthValidationError)]
        [Display(Name = "Manufacturer Phone Number")]
        public string ManufacturerPhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = StringLengthValidationError)]
        [Display(Name = "Manufacturer Address")]
        public string ManufacturerAddress { get; set; } = null!;

        [Required]
        public int CityId { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; } = new List<CityViewModel>();

        [EmailAddress] 
        public string? UserEmail { get; set; }
    }
}
