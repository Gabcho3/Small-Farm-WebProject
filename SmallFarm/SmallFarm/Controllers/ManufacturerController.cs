using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Manufacturer;
using SmallFarm.Data.Entities;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Controllers
{
    [Authorize(Roles = Admin.RoleName)]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService manufacturerService;
        private readonly IProductService productService;

        private readonly UserManager<ApplicationUser> userManager;
        
        public ManufacturerController(IManufacturerService manufacturerService, 
            UserManager<ApplicationUser> _userManager,
            IProductService _productService)
        {
            this.manufacturerService = manufacturerService;
            this.productService = _productService;
            this.userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allManufacturers = await manufacturerService.GetAllManufacturersAsync();

            return View(allManufacturers);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await manufacturerService.GetManufacturerByIdAsync(id);
            model.Cities = await manufacturerService.GetAllCitiesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ManufacturerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await manufacturerService.EditManufacturerAsync(id, model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            await manufacturerService.DeleteManufacturerAsync(id);

            return RedirectToAction("Index");
        }
    }
}
