using Microsoft.AspNetCore.Mvc;
using ScoobWebApp.Models;
using System.Diagnostics;

namespace ScoobWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Relationship()
        {
            var relationshipClient = new ScoobyRelationshipAPI("http://scoobyapi:8003", new HttpClient());

            var result = await relationshipClient.GetScoobyRelationsAsync();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}