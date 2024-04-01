using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static SmallFarm.Common.DataConstants.UserConstants;

namespace SmallFarm.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}
