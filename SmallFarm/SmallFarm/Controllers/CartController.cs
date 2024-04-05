using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Product;
using SmallFarm.Data.Entities;
using SmallFarm.Extensions;

namespace SmallFarm.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICartService service;

        public CartController(UserManager<ApplicationUser> _userManager, ICartService _service)
        {
            this.userManager = _userManager;
            this.service = _service;
        }

        [Authorize]
        [Route("Cart/MyCart/{id}")]
        public async Task<IActionResult> Index(Guid id)
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Register");
            }

            if (User.IsManufacturer())
            {
                return RedirectToAction("Index", "Product");
            }

            var models = await service.GetAllProductsInCartAsync(userManager.GetUserId(User));

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductToBuyModel model)
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Register");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Product", new { model.Id });
            }

            await service.AddAsync(model);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Remove(Guid id)
        {
            await service.RemoveAsync(id, userManager.GetUserId(User));

            return RedirectToAction("Index");
        }
    }
}
