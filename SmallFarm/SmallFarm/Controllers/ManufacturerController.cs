using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Manufacturer;

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
        public async Task<IActionResult> Add()
        {
            var model = new ManufacturerFormModel()
            {
                Cities = await service.GetAllCitiesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ManufacturerFormModel model)
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
            model.Cities = await service.GetAllCitiesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ManufacturerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.EditManufacturerAsync(id, model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            await service.DeleteManufacturerAsync(id);

            return RedirectToAction("Index");
        }
    }
}
