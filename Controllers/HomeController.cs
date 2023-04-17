using Microsoft.AspNetCore.Mvc;
using PageApplication.Models;
using PageApplication.Services;
using System.Diagnostics;

namespace PageApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;

        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
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

        public JsonResult GetItems()
        {
            var items = _itemService.GetItems();
            return Json(items);
        }

        public async Task<IActionResult> GetAsyncItems()
        {
            var items = await _itemService.GetItemsAsync() ?? new List<string>();
            return Json(items);
        }
    }
}