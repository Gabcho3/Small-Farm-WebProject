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
        private readonly IOrderService service;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderService _service, UserManager<ApplicationUser> _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Order()
        {
            await service.OrderAsync(userManager.GetUserId(User));

            return RedirectToAction("Index");
        }
    }
}
