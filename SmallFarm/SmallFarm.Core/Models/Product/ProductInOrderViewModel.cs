namespace SmallFarm.Core.Models.Product
{
    public class ProductInOrderViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
