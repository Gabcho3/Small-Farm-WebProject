using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = Admin.RoleName)]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            this.manufacturerService = manufacturerService;
        }

        [HttpGet]
        [Route("/AllManufacturers")]
        public async Task<IActionResult> Index()
        {
            var allManufacturers = await manufacturerService.GetAllManufacturersAsync();

            return View(allManufacturers);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            await manufacturerService.DeleteManufacturerAsync(id);

            return RedirectToAction("Index");
        }
    }
}
