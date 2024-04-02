using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Request;
using SmallFarm.Core.Services;

namespace SmallFarm.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IRequestService requestService;
        private readonly IManufacturerService manufacturerService;

        public RequestController(IRequestService _requestService, IManufacturerService _manufacturerService)
        {
            this.requestService = _requestService;
            this.manufacturerService = _manufacturerService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Submit()
        {
            var request = new RequestFormModel()
            {
                UserEmail = User.Identity!.Name!,
                Cities = await manufacturerService.GetAllCitiesAsync()
            };

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(RequestFormModel form)
        {
            form.UserEmail = User.Identity!.Name!;

            if (!ModelState.IsValid)
            {
                form.Cities = await manufacturerService.GetAllCitiesAsync();
                return View(form);
            }

            await requestService.AddAsync(form);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Approve()
        {
            return RedirectToAction("Add", "Manufacturer");
        }
    }
}
