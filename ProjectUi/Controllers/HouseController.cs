using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectUi.Models;
using ProjectUi.Temp;

namespace ProjectUi.Controllers
{
    public class HouseController : Controller
    {
        Helper helper = new Helper();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HouseKeeping()
        {
         


            var exist = helper.fileRead("HouseKeepingModel");
            var existList = string.IsNullOrEmpty(exist) ? new List<HouseKeeping>() : JsonConvert.DeserializeObject<List<HouseKeeping>>(exist);
           

            var UpdateData = JsonConvert.SerializeObject(existList);
            helper.UpdateToFile("HouseKeepingModel", UpdateData);
            return View(existList);
        }
    }
}
