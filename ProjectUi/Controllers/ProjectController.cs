using Microsoft.AspNetCore.Mvc;
using ProjectUi.Models;
using System.Xml.Linq;
using System.IO;
using ProjectUi.Temp;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace ProjectUi.Controllers
{
    
    public class ProjectController : Controller
    {

        Helper helper = new Helper();

       
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
            var updateData= JsonConvert.SerializeObject(data);
            helper.UpdateToFile("GuestModel", updateData);
            
            //Count month no of dates
            var numberOfDate = DateTime.DaysInMonth(year, month);
           
            var main = new MainModel();
            main.NoOfDaysInMonth = numberOfDate;
            main.guestModals=data;
            main.currentYear = year;
            main.currentMonth = month;
            
            return PartialView("_PartialViewModel", main);
        }
        
   


         public IActionResult Restaurant()
        {
          
          
            var exist = helper.fileRead("RestaurantModel");
            var exitList = string.IsNullOrEmpty(exist) ? new List<RestaurantModel>() : JsonConvert.DeserializeObject<List<RestaurantModel>>(exist);
            var UpdateData = JsonConvert.SerializeObject(exitList);
            helper.UpdateToFile("RestaurantModel", UpdateData);

            return View(exitList);
         }

        public IActionResult Laundry()
        {
           
           

            var exist = helper.fileRead("LaundryModel");
            var exitList = string.IsNullOrEmpty(exist) ? new List<Laundry>() : JsonConvert.DeserializeObject<List<Laundry>>(exist);

            var UpdateData = JsonConvert.SerializeObject(exitList);
            helper.UpdateToFile("LaundryModel", UpdateData);
            return View(exitList);
        }
       
        

        public IActionResult AssetManagement()
        {
           
            var exist = helper.fileRead("AssetManagementModel");
            var existList = string.IsNullOrEmpty(exist) ? new List<AssetManageMent>() : JsonConvert.DeserializeObject<List<AssetManageMent>>(exist);
            
            var UpdateData = JsonConvert.SerializeObject(existList);
            helper.UpdateToFile("AssetManagementModel", UpdateData);
            return View(existList);
            
        }
        public IActionResult Payrol()
        {
            var exist = helper.fileRead("PayrolModel");
            var existList = string.IsNullOrEmpty(exist)?new List<PayRoll>() : JsonConvert.DeserializeObject<List<PayRoll>>(exist);
           

            var updateData= JsonConvert.SerializeObject(existList);
            helper.UpdateToFile("PayrolModel", updateData);
            return View(existList);
        }
     }
    
}
