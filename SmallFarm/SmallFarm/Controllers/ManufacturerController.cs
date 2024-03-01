using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models;
using SmallFarm.Core.Services;
using SmallFarm.Models;

namespace SmallFarm.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService service;

        public ManufacturerController(IManufacturerService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allManufacturers = await service.GetAllManufacturersAsync();

            return View(allManufacturers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ManufacturerViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ManufacturerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.AddManufacturerAsync(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await service.GetManufacturerByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ManufacturerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.EditManufacturerAsync(id, model);

            return RedirectToAction("Index");
        }
    }
}
