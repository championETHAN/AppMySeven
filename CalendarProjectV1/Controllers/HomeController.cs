using CalendarProjectV1.Data;
using CalendarProjectV1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalendarProjectV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalendarProjectDbContext calendarProjectDbContext;

        public HomeController(CalendarProjectDbContext calendarProjectDbContext)
        {
            this.calendarProjectDbContext = calendarProjectDbContext;
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
    }
}