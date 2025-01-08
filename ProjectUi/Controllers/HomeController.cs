using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectUi.Models;

namespace ProjectUi.Controllers
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
            //Fake data for months
            var data = new List<Month>
            {
                new Month { id = 1, months = "Jan" }
                ,
                new Month { id = 2, months = "Feb" }
              ,
                new Month { id = 3, months = "Mar" }
              ,
                new Month { id = 4, months = "Apr" }
              ,
                new Month { id = 5, months = "May" }
              ,
                new Month { id = 6, months = "Jun" }
              ,
                new Month { id = 7, months = "Jul" }
              ,
                new Month { id = 8, months = "Aug" }
              ,
                new Month { id = 9, months = "Sept" }
              ,
                new Month { id = 10, months = "Oct" }
              ,
                new Month { id = 11, months = "Nov" }
              ,
                new Month { id = 12, months = "Dec" }
            };
            //fake data for years
            var year = new List<Year>
            {
                new Year{Years=2022},
                new Year{Years=2023},
                new Year{Years=2024},
                new Year{Years=2025},
                new Year{Years=2026},
                new Year{Years=2027},
                new Year{Years=2028},
            };
            //Add year and month to main model
            MainModel main = new MainModel();
            main.years = year;
            main.months = data;
            //find current month and year
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            foreach (var item in data)
            {
                if (currentMonth == item.id)
                {
                    item.currentMonth = item.id;
                }
            }
            foreach (var item in year)
            {
                if (currentYear == item.Years)
                {
                    item.currentYear = currentYear;
                }
            }
            return View(main);
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
