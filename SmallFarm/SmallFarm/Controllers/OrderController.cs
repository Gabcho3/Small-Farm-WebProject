using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Data.Entities;

namespace SmallFarm.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderService orderService, ICartService _cartService, UserManager<ApplicationUser> _userManager)
        {
            this.orderService = orderService;
            this.cartService = _cartService;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetOrdersAsync(UserId);

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Order()
        {
            TempData["hasOrdered"] = true;

            if (cartService.GetProductsInCartCount(UserId) == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            await orderService.OrderAsync(UserId);

            return RedirectToAction("Index");
        }

        private string UserId => userManager.GetUserId(User);
    }
}
