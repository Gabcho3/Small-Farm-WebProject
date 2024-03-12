using SmallFarm.Core.Models.City;
using System.ComponentModel.DataAnnotations;
using static SmallFarm.Common.DataConstants.ManufacturerConstants;
using static SmallFarm.Common.ValidationErrors.GeneralValidationErrors;

namespace SmallFarm.Core.Models.Manufacturer
{
    public class ManufacturerFormModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthValidationError)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = StringLengthValidationError)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, ErrorMessage = StringMaxLengthValidationError)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = StringMaxLengthValidationError)]
        public string Address { get; set; } = null!;

        public int CityId { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; } = Enumerable.Empty<CityViewModel>();
    }
}
