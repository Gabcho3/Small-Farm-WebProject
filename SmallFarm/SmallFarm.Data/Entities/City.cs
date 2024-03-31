using System.ComponentModel.DataAnnotations;

namespace SmallFarm.Data.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
