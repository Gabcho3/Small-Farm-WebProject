﻿using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Contracts
{
    public interface ICartService
    {
        Task<IEnumerable<ProductToBuyModel>> GetAllProductsInCartAsync(string userId);

        Task AddAsync(ProductToBuyModel model);

        Task RemoveAsync(Guid productId, string userId);
    }
}
