using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Extensions;

namespace SmallFarm.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService orderService, ICartService _cartService)
        {
            this.orderService = orderService;
            this.cartService = _cartService;
        }

        [Route("Order/MyOrders/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return RedirectToPage("/Identity/Account/Register");
            }

            if (User.IsManufacturer())
            {
                return RedirectToAction("Index", "Home");
            }

            var orders = await orderService.GetOrdersAsync(id);

            return View(orders);
        }

        [HttpGet]
        [Route("Order/PlaceOrder/{id}")]
        public async Task<IActionResult> Order(string id)
        {
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
    }
}
