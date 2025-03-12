using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using ProjectUi.Models;
using ProjectUi.Temp;
using SixLabors.ImageSharp.PixelFormats;
using SkiaSharp;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectUi.Controllers
{
    public class EmployeeController : Controller
    {
        Helper helper = new Helper();
        public IActionResult EmployeeManagement()
        {

            var exist = helper.fileRead("EmployeeManagementModel");
            var existList = string.IsNullOrEmpty(exist) ? new List<EmployeeManagement>() : JsonConvert.DeserializeObject<List<EmployeeManagement>>(exist);

            var UpdateData = JsonConvert.SerializeObject(existList);
            helper.UpdateToFile("EmployeeManagementModel", UpdateData);
            return View(existList);
        }
        [HttpPost]
        public IActionResult Create(EmployeeManagement model)
        {
            // Retrieve the uploaded file from the form.
            var file = HttpContext.Request.Form.Files.FirstOrDefault();

            if (file == null || file.Length == 0)
            {
                return Json(new { success = false, message = "Please select an employee image." });
            }

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    // Load the image using SkiaSharp
                    using (var img = SKBitmap.Decode(stream))
                    {
                        if (img == null)
                        {
                            return Json(new { success = false, message = "Invalid image file." });
                        }

                        int width = img.Width;
                        int height = img.Height;
                        // Calculate megapixels.
                        double megapixels = (width * height) / 1000000.0;
                        if (megapixels >= 1)
                        {
                            return Json(new { success = false, message = "Image quality is too high. Please upload an image less than 1 Megapixel." });
                        }

                        // Convert the image to Base64
                        using (var ms = new MemoryStream())
                        {
                            using (var image = SKImage.FromBitmap(img))
                            using (var data = image.Encode(SKEncodedImageFormat.Jpeg, 100))
                            {
                                data.SaveTo(ms);
                            }
                            byte[] imageBytes = ms.ToArray();
                            string base64String = Convert.ToBase64String(imageBytes);
                            model.Photo = $"data:image/jpeg;base64,{base64String}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(model,new { success = false, message = "Error processing image file: " + ex.Message });
            }
            var listEmp = new List<EmployeeManagement>();

            listEmp.Add(model);
            MainModel main=new MainModel();
            main.employeeManagement = listEmp;
            var exist = helper.fileRead("EmployeeManagementModel");
            var existList = string.IsNullOrEmpty(exist) ? new List<EmployeeManagement>() : JsonConvert.DeserializeObject<List<EmployeeManagement>>(exist);
            existList.Add(model);
            var UpdateData = JsonConvert.SerializeObject(existList);
            helper.UpdateToFile("EmployeeManagementModel", UpdateData);
            return Json(new { success = true, message = "Employee details saved successfully!" });
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
           
            var exist = helper.fileRead("EmployeeManagementModel");
            var existList = string.IsNullOrEmpty(exist) ? new List<EmployeeManagement>() : JsonConvert.DeserializeObject<List<EmployeeManagement>>(exist);
          
            var employee = existList.FirstOrDefault(e => e.SNo == id);

            if (employee == null || string.IsNullOrEmpty(employee.Photo))
            {
                return Json(new { success = false, message = "Image not found." });
            }

           
                // Remove the data URL prefix (e.g., "data:image/jpeg;base64,")
                var base64String = employee.Photo.Split(',')[1];
                byte[] imageBytes = Convert.FromBase64String(base64String);

                // Create a unique file name
                string fileName = $"employee_{id}_{Guid.NewGuid()}.jpg";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Ensure the directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Save the image to wwwroot/images
                System.IO.File.WriteAllBytes(filePath, imageBytes);

                // Generate the image URL
                string imageUrl = $"{Request.Scheme}://{Request.Host}/images/{fileName}";
                employee.Photo = imageUrl;


                return Json(employee);
            
        }
       public IActionResult Search(string SearchBY,string SearchValue)
        {
            var searchData = new List<EmployeeManagement>();
            switch (SearchBY)
            {
                case "Dept":
                    var DeptExistData = helper.fileRead("EmployeeManagementModel");
                    var DeptExistDataList = string.IsNullOrEmpty(DeptExistData) ? new List<EmployeeManagement>() : JsonConvert.DeserializeObject<List<EmployeeManagement>>(DeptExistData);
                    var DeptResult = DeptExistDataList.Where(x => x.Department.ToLower() == SearchValue.ToLower()).ToList();

                    return PartialView("EmployeePartialView", DeptResult);

                case "Designation":
                    var DesignationExistData = helper.fileRead("EmployeeManagementModel");
                    var DesignationExistDataList = string.IsNullOrEmpty(DesignationExistData) ? new List<EmployeeManagement>() : JsonConvert.DeserializeObject<List<EmployeeManagement>>(DesignationExistData);
                    var DesignationResult = DesignationExistDataList.Where(x => x.Designation.ToLower() == SearchValue.ToLower()).ToList();
                    return PartialView("EmployeePartialView", DesignationResult);
            }
            return View();
            
        }
    }
   

}
    