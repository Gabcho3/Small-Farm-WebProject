using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Common.DataConstants;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Product;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly UserManager<IdentityUser> userManager;

        public ProductController(IProductService _service, UserManager<IdentityUser> _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index([FromQuery]AllProductsQueryModel queryModel)
        {
            var result = await service.GetAllAsync(queryModel);

            queryModel.TotalProductsCount = result.TotalProductsCount;
            queryModel.Products = result.Products;

            return View(queryModel);
        }

        [HttpGet]
        [Authorize(Roles = Manufacturer.RoleName)]
        public IActionResult Add()
        {
            return View(new ProductFormModel());
        }

        [HttpPost]
        [Authorize(Roles = Manufacturer.RoleName)]
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
