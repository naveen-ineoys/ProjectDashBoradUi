namespace ProjectUi.Models
{
    public class MainModel
    {
        public int id { get; set; }
        public List<Month> months { get; set; }
        public List<Year> years { get; set; }

        public List<GuestModel> guestModals { get; set; }

        public List<EmployeeManagement> employeeManagement { get; set; }

        public int NoOfDaysInMonth { get; set; }
        public int currentMonth { get; set; }
        public int currentYear { get; set; }
        public DateTime currentdate {get;set;}
        public string onlyDate { get; set; }
        public int TotalNoOfRooms { get; set; } = 50;
        public List<StatusModel> statusModels { get; set; }
        public int Arrivals { get; set; }
        public int Depature { get; set; }
        public int InHouse { get; set; }
        public int Booked { get; set; } 
        public int Available { get; set; } 
        public int Blocked { get; set; } = 2;

        public double BookedPercentage { get; set; }
        public double AvailablePercentage { get; set; }
        public double BlockedPercentage { get; set; }
    }
}



