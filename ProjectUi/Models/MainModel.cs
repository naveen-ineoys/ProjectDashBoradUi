namespace ProjectUi.Models
{
    public class MainModel
    {
        public int id { get; set; }
        public List<Month> months { get; set; }
        public List<Year> years { get; set; }

        public List<GuestModel> guestModals { get; set; }

        public List<GuestStatus> guestStatuses { get; set; }
        public int NoOfDaysInMonth { get; set; }
        public int currentMonth { get; set; }
        public int currentYear { get; set; }
        public int TotalNoOfRooms { get; set; } = 29;

    }
}
