﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Product;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly SmallFarmDbContext context;

        private readonly IMapper mapper;

        public ProductService(SmallFarmDbContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<ProductToBuyModel> GetByIdAsync(Guid productId)
            => mapper.Map<ProductToBuyModel>(await context.Products
                .Include(p => p.Manufacturer)
                .FirstAsync(p => p.Id == productId));

        public async Task<ProductQueryModel> GetAllAsync(AllProductsQueryModel queryModel)
        {
            var result = new ProductQueryModel();

            var products = context.Products
                .Include(p => p.Manufacturer)
                .AsQueryable();

            if (!string.IsNullOrEmpty(queryModel.SearchTerm))
            {
                var searchTerm = $"%{queryModel.SearchTerm.ToLower()}%";

                products = products
                    .Where(p => EF.Functions.Like(p.Name.ToLower(),searchTerm) ||
                                EF.Functions.Like(p.Manufacturer.Name.ToLower(), searchTerm));
            }

            if (queryModel.MinPrice >= 0 && queryModel.MaxPrice > 0)
            {
                products = products.Where(p => p.Price >= queryModel.MinPrice && p.Price <= queryModel.MaxPrice);
            }

            products = (int)queryModel.Sorting switch
            {
                1 => products.OrderByDescending(p => p.Price),
                2 => products.OrderBy(p => p.Quantity),
                3 => products.OrderByDescending(p => p.Quantity),
                _ => products.OrderBy(p => p.Price),
            };

            result.Products = await products
                .Skip((queryModel.CurrentPage - 1) * 4)
                .Take(4)
                .Select(p => mapper.Map<ProductViewModel>(p))
                .ToListAsync();

            result.TotalProductsCount = await products.CountAsync();

            return result;
        }

        public async Task AddAsync(ProductFormModel productForm)
        {
            var productToAdd = mapper.Map<Product>(productForm);

            await context.AddAsync(productToAdd);
            await context.SaveChangesAsync();
        }
    }
}

