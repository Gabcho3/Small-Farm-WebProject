using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Product;

namespace SmallFarm.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService _service)
        {
            this.service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var products = await service.GetProductsAsync();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProductFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            await service.AddAsync(formModel);

            return RedirectToAction("Index");
        }
    }
}
