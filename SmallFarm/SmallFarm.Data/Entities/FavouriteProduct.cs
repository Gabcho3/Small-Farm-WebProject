using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SmallFarm.Data.Entities
{
    public class FavouriteProduct
    {
        public string ClientId { get; set; } = null!;

        [ForeignKey(nameof(ClientId))]
        public IdentityUser Client { get; set; } = null!;

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
