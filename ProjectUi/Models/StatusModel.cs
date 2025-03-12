namespace ProjectUi.Models
{
    public class StatusModel
    {
        public int Arrivals { get; set; }
        public int Depature { get; set; }
        public int InHouse { get; set; }

       
        public int Booked { get; set; } = 15;
        public int Available { get; set; } = 24;
        public int Blocked { get; set; } = 2;

        public double BookedPercentage { get; set; }
        public double AvailablePercentage { get; set; }
        public double BlockedPercentage { get; set; }
    }
}
