using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFarm.Data.Entities
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
