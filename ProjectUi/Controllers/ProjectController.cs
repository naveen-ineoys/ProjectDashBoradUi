using Microsoft.AspNetCore.Mvc;
using ProjectUi.Models;

namespace ProjectUi.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult MainView()
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
            var currentYear= DateTime.Now.Year;
            
            foreach (var item in data)
            {
                if(currentMonth == item.id)
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


        public IActionResult FindNumberOfDays(int year, int month)
        {
            //Fake data for guest view
            var data = new List<GuestModel> {
            new GuestModel { RoomId = 101, GuestName = "John ", CheckInDate = new DateTime(2024, 12, 12), CheckOutDate = new DateTime(2024, 12, 14) ,Status="Arrived"},
            new GuestModel { RoomId = 101, GuestName = "Anbu ", CheckInDate = new DateTime(2024, 12, 6), CheckOutDate = new DateTime(2024, 12, 7),Status="Stay" },
            new GuestModel { RoomId = 102, GuestName = "John ", CheckInDate = new DateTime(2024, 12, 12), CheckOutDate = new DateTime(2024, 12, 14),Status="Left" },
            new GuestModel { RoomId = 102, GuestName = "naveen ", CheckInDate = new DateTime(2024, 12, 10), CheckOutDate = new DateTime(2024, 12, 13),Status="Left" },
            new GuestModel { RoomId = 102, GuestName = "Jana", CheckInDate = new DateTime(2024, 12, 20), CheckOutDate = new DateTime(2024, 12, 25),Status="Stay" },
            new GuestModel { RoomId = 102, GuestName = "Jana", CheckInDate = new DateTime(2024, 12, 2), CheckOutDate = new DateTime(2024, 12, 5),Status="Arrived" },
            new GuestModel { RoomId = 102, GuestName = "Jana", CheckInDate = new DateTime(2024, 12, 8), CheckOutDate = new DateTime(2024, 12, 11) ,Status="Arrived"},
              new GuestModel { RoomId = 102, GuestName = "naveen ", CheckInDate = new DateTime(2024, 12, 10), CheckOutDate = new DateTime(2024, 12, 13),Status="Arrived" },
                new GuestModel { RoomId = 102, GuestName = "naveen ", CheckInDate = new DateTime(2024, 12, 10), CheckOutDate = new DateTime(2024, 12, 13),Status="Stay" },
                  new GuestModel { RoomId = 102, GuestName = "naveen ", CheckInDate = new DateTime(2024, 12, 10), CheckOutDate = new DateTime(2024, 12, 13),Status="Arrived" },
            };
          
            
            //Count month no of dates
            var numberOfDate = DateTime.DaysInMonth(year, month);
           
            var main = new MainModel();
            main.NoOfDaysInMonth = numberOfDate;
            main.guestModals=data;
            main.currentYear = year;
            main.currentMonth = month;
         

            return PartialView("_PartialViewModel", main);
        }
      
    }
}
