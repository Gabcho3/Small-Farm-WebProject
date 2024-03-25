namespace SmallFarm.Core.Models.Product
{
    public class ProductQueryModel
    {
        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    }
}
