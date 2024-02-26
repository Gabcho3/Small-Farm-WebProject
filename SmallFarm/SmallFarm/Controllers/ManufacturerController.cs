using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Services;

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
    }
}
