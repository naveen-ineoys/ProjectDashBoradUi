namespace ProjectUi.Models
{
    public class ReservationModel
    {
        public string BookingId { get; set; }

        public string CustomerName { get; set; }
        public string ClientId { get; set; }
        public int RoomNo { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }


    }
}
