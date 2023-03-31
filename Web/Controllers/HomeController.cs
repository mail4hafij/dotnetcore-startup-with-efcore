using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web.Models;
using Common;

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

        public async Task<IActionResult> Index()
        {
            var resp = _coreService.GetUser(new Common.Contract.Messaging.GetUserReq()
            {
                Email = "admin@efcore.com"
            });

            _coreService.AddOrganization(new Common.Contract.Messaging.AddOrganizationReq()
            {
                UserId = resp.userContract.UserId,
                OrganizationName = "Test organization"
            });
            
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