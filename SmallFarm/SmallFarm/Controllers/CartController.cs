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
        public async Task<IActionResult> Index(string id)
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Register");
            }

            if (userManager.GetUserId(User) != id)
            {
                return RedirectToAction("Error404", "Home");
            }

            if (User.IsManufacturer())
            {
                return RedirectToAction("Index", "Product");
            }

            var models = await service.GetAllProductsInCartAsync(UserId);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductToBuyModel model)
        {

            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Register");
            }

            if (!ModelState.IsValid && model.Image != null)
            {
                return RedirectToAction("Details", "Product", new { model.Id });
            }

            await service.AddAsync(model);

            string id = UserId;
            return RedirectToAction("Index", "Cart", new { id });
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Remove(Guid id)
        {
            await service.RemoveAsync(id, UserId);

            id = Guid.Parse(UserId);
            return RedirectToAction("Index", "Cart", new{id});
        }

        private string UserId => userManager.GetUserId(User);
    }
}
