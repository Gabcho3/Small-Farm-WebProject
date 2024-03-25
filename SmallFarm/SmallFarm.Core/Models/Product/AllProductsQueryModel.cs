using SmallFarm.Core.Enums;

namespace SmallFarm.Core.Models.Product
{
    public class AllProductsQueryModel
    {
        public string? SearchTerm { get; set; } = string.Empty;

        public ProductSorting Sorting { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    }
}
