using System.ComponentModel.DataAnnotations;
using static SmallFarm.Common.DataConstants.CityConstants;

namespace SmallFarm.Data.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CityMaxLength)]
        public string Name { get; set; } = null!;
    }
}
