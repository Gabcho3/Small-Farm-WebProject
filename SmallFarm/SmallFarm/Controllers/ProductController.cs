using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Common.DataConstants;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Product;
using SmallFarm.Data.Entities;
using SmallFarm.Extensions;

namespace SmallFarm.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductController(IProductService _service, UserManager<ApplicationUser> _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index([FromQuery] AllProductsQueryModel queryModel)
        {
            var result = await service.GetAllAsync(queryModel);

            queryModel.TotalProductsCount = result.TotalProductsCount;
            queryModel.Products = result.Products;

            return View(queryModel);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.Manufacturer.RoleName)]
        public async Task<IActionResult> Add()
        {
            var model = new ProductFormModel()
            {
                ProductCategories = await service.GetAllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.Manufacturer.RoleName)]
        public async Task<IActionResult> Add(ProductFormModel formModel)
        {
            formModel.ManufacturerId = Guid.Parse(userManager.GetUserId(User));

            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            await service.AddAsync(formModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await service.GetByIdAsync(id);

            return View(product);
        }
    }
}
