namespace SmallFarm.Core.Models.Manufacturer
{
    public class ManufacturerViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
