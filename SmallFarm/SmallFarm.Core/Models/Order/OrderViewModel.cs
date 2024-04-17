using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Models.Order
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public DateTime OrderedDate { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsActive { get; set; } = true;

        public string Contacts { get; set; }

        public List<ProductInOrderViewModel> Products { get; set; } = new List<ProductInOrderViewModel>();
    }
}
