using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Models.Order
{
    public class OrderViewModel
    {
        public DateTime OrderedDate { get; set; }

        public decimal TotalPrice { get; set; }

        public List<ProductInOrderViewModel> Products { get; set; } = new List<ProductInOrderViewModel>();
    }
}
