using System.ComponentModel.DataAnnotations;
using static SmallFarm.Common.DataConstants.ManufacturerConstants;
using static SmallFarm.Common.ValidationErrors.GeneralValidationErrors;

namespace SmallFarm.Core.Models
{
    public class ManufacturerViewModel
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
        public string Address { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;
    }
}
