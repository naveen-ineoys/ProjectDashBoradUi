using ProjectUi.Models;
using ProjectUi.Temp;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace ProjectUi.Temp
{
    public class Helper
    {
       
        static string filePath = "C:\\Users\\jnave\\Source\\Repos\\ProjectDashBoradUi\\ProjectUi\\Temp\\";

        public void UpdateToFile(string ModelName, string data)
        {
            switch (ModelName)
            {
                case "ReservationModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;
                case "RestaurantModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;

                case "LaundryModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;
                case "HouseKeepingModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;
                case "EmployeeManagementModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;
                case "AssetManagementModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;
                case "PayrolModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;
                case "GuestModel":
                    File.WriteAllText(filePath + ModelName + ".txt", data);
                    break;
            }
        }
        public string fileRead(string ModelName)
        {
            return File.ReadAllText(filePath + ModelName + ".txt");
        }
    }
}
