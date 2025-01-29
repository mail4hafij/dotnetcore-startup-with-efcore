using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web.Models;
using Common.Contract.Messaging;
using Common;
using Common.Contract;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoreService _coreService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICoreService coreService, ILogger<HomeController> logger)
        {
            _coreService = coreService;
            _logger = logger;
        }

        public IActionResult Index([FromQuery] QueryParameters qp)
        {
            var resp = _coreService.GetUser(new GetUserReq()
            {
                Email = "admin@efcore.com"
            });

            _coreService.AddCar(new AddCarReq()
            {
                UserId = resp.userContract.UserId,
                Nameplate = "FREPLSTN"
            });

            var carResp = _coreService.GetAllCar(new GetAllCarReq()
            {
                Email = resp.userContract.Email,
                QueryParameters = qp
            });

            ViewData["cars"] = carResp.carContracts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}