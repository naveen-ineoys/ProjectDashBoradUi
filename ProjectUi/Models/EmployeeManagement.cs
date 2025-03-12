using System.ComponentModel.DataAnnotations;

namespace ProjectUi.Models
{
    public class EmployeeManagement
    {
       
        public int SNo { get; set; }
        public string Photo {  get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }

        public DateTime DOB { get; set; }
        public DateTime DateOfJoin { get; set; }
        
        public string? JobType { get; set; }


        
    }
}
