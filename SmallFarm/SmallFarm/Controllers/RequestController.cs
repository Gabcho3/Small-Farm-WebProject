using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Request;

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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allCities = await manufacturerService.GetAllCitiesAsync();

            var requests = await requestService.GetAllAsync();
            requests.ForEach(r => r.Cities = allCities);

            return View(requests);
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

        [HttpGet]
        public async Task<IActionResult> Approve(Guid id)
        {
            await requestService.ApproveAsync(id);

            return RedirectToAction("Index");
        }
    }
}
