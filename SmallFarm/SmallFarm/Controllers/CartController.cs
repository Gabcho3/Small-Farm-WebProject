using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Models.Product;

namespace SmallFarm.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public CartController(UserManager<IdentityUser> _userManager)
        {
            this.userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductToBuyModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Product", new{model.Id});
            }

            return RedirectToAction("Index");
        }
    }
}
