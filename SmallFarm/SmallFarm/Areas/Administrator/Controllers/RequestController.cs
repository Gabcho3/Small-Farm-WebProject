using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Request;

namespace SmallFarm.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class RequestController : Controller
    {
        private readonly IRequestService requestService;
        private readonly IManufacturerService manufacturerService;

        public RequestController(IRequestService _requestService, IManufacturerService _manufacturerService)
        {
            requestService = _requestService;
            manufacturerService = _manufacturerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allCities = await manufacturerService.GetAllCitiesAsync();

            var requests = await requestService.GetAllAsync();
            requests.ForEach(r => r.Cities = allCities);

            return View(requests);
        }

        [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> Approve(Guid id)
        {
            await requestService.ApproveAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Disapprove(Guid id)
        {
            await requestService.DisapproveAsync(id);

            return RedirectToAction("Index");
        }
    }
}
