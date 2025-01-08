using Microsoft.AspNetCore.Mvc;
using ProjectUi.Models;

namespace ProjectUi.Controllers
{
    public class ProjectController : Controller
    {
       

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
