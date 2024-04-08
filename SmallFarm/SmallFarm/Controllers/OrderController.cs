using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Data.Entities;
using SmallFarm.Extensions;

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

        [Route("Order/MyOrders/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if (userManager.GetUserId(User) != id)
            {
                return RedirectToAction("Error404", "Home");
            }

            if (!User.Identity!.IsAuthenticated)
            {
                return RedirectToPage("/Identity/Account/Register");
            }

            if (User.IsManufacturer())
            {
                var myOrders = await orderService.GetManufacturerOrdersAsync(id);
                return View(myOrders);
            }

            var orders = await orderService.GetOrdersAsync(id);

            return View(orders);
        }

        [HttpGet]
        [Route("Order/PlaceOrder/{id}")]
        public async Task<IActionResult> Order(string id)
        {
            if (userManager.GetUserId(User) != id)
            {
                return RedirectToAction("Error404", "Home");
            }

            if (User.IsManufacturer())
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["hasOrdered"] = true;

            if (cartService.GetProductsInCartCount(id) == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            await orderService.OrderAsync(id);

            return RedirectToAction("Index", new{id});
        }

        [HttpGet]
        [Authorize(Roles = "Manufacturer")]
        public async Task<IActionResult> Confirm(Guid id)
        {
            if (!User.IsManufacturer())
            {
                return RedirectToAction("Error404", "Home");
            }

            await orderService.ConfirmAsync(id);

            return RedirectToAction("Index", new { id });
        }
    }
}
