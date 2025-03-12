using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectUi.Models;
using ProjectUi.Temp;

namespace ProjectUi.Controllers
{
    public class FrontDeskController : Controller
    {
        Helper helper = new Helper();

        public IActionResult FrontDeskDashBoard()
        {
            var data = helper.fileRead("GuestModel");
            var newData = JsonConvert.DeserializeObject<List<GuestModel>>(data);
            var month = DateTime.Now.Month;
            var onlyDate = DateTime.Now.Day.ToString();
            var day = DateTime.Now;
            var main = new MainModel();
            main.guestModals = newData;
            main.currentdate = day;
            main.onlyDate = onlyDate;

            var countofarr = newData.Count(a => a.Status == "Arrived");
            var countofDep = newData.Count(d => d.Status == "Left");
            var countofStay = newData.Count(s => s.Status == "Stay");
            main.Arrivals = countofarr;
            main.Depature = countofDep;
            main.InHouse = countofStay;
            for (int i = 1; i <= 30; i++)
            {
                if (main.onlyDate == "" + i + "")
                {
                    int totalBookings = main.guestModals.Count(g => g.CheckInDate.Day <= i && g.CheckOutDate.Day >= i);
                    int totalAvailable = main.TotalNoOfRooms - totalBookings;
                    main.Booked = totalBookings;
                    main.Available = totalAvailable - 2;
                    break;
                }
            }

            main.BookedPercentage = ((double)main.Booked / main.TotalNoOfRooms) * 100;
            main.AvailablePercentage = ((double)main.Available / main.TotalNoOfRooms) * 100;
            main.BlockedPercentage = ((double)main.Blocked / main.TotalNoOfRooms) * 100;

            return View(main);
        }


        public IActionResult SortTheData(string SortByStatus, string SortOrder, string Sortby)
        {

            var main = new MainModel();
            var data = helper.fileRead("GuestModel");
            var newData = JsonConvert.DeserializeObject<List<GuestModel>>(data);
            switch (SortOrder)
            {
                case "ascending":
                    switch (Sortby)
                    {
                        case "guest":
                            var sortByStatusGuest = newData.Where(x => x.Status == SortByStatus);
                            var asceByName = sortByStatusGuest.OrderBy(x => x.GuestName);

                            main.guestModals = asceByName.ToList();
                            break;
                        case "accomadation":
                            var sortByStatusAcc = newData.Where(x => x.Status == SortByStatus);
                            var asceByRoomNo = sortByStatusAcc.OrderBy(x => x.RoomId);

                            main.guestModals = asceByRoomNo.ToList();
                            break;
                        case "stay":
                            var sortByStatusStay = newData.Where(x => x.Status == SortByStatus);
                            var asceByDate = sortByStatusStay.OrderBy(x => x.CheckInDate);

                            main.guestModals = asceByDate.ToList();
                            break;

                    }
                    break;


                case "descending":
                    switch (Sortby)
                    {
                        case "guest":
                            var sortByStatusGuest = newData.Where(x => x.Status == SortByStatus);
                            var asceByName = sortByStatusGuest.OrderByDescending(x => x.GuestName);

                            main.guestModals = asceByName.ToList();
                            break;
                        case "accomadation":
                            var sortByStatusAcc = newData.Where(x => x.Status == SortByStatus);
                            var asceByRoomNo = sortByStatusAcc.OrderByDescending(x => x.RoomId);

                            main.guestModals = asceByRoomNo.ToList();
                            break;
                        case "stay":
                            var sortByStatusStay = newData.Where(x => x.Status == SortByStatus);
                            var asceByDate = sortByStatusStay.OrderByDescending(x => x.CheckInDate);

                            main.guestModals = asceByDate.ToList();
                            break;

                    }
                    break;
            }


            return PartialView("FrontDeskPartial", main);
        }
    }
}
