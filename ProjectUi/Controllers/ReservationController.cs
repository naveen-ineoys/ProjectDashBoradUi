using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectUi.Models;
using ProjectUi.Temp;

namespace ProjectUi.Controllers
{ 
    public class ReservationController : Controller
    {
        Helper helper = new Helper();

        public IActionResult Reservation()
        {
            var exist = helper.fileRead("ReservationModel");

            var existList = string.IsNullOrEmpty(exist) ? new List<ReservationModel>() : JsonConvert.DeserializeObject<List<ReservationModel>>(exist);



            var UpdateData = JsonConvert.SerializeObject(existList);

            helper.UpdateToFile("ReservationModel", UpdateData);

            return View();
        }
    }
}
