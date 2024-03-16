using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Manufacturer;

namespace SmallFarm.Controllers
{
    [Authorize]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService service;
        private readonly UserManager<IdentityUser> userManager;

        public ManufacturerController(IManufacturerService _service, UserManager<IdentityUser> _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
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

            var manufacturer = await userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (manufacturer == null)
            {
                return View(model);
            }

            model.Id = Guid.Parse(await userManager.GetUserIdAsync(manufacturer));
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
