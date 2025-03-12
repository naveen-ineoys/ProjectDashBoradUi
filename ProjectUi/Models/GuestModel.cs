namespace ProjectUi.Models
{
    public class GuestModel
    {
     
        
        public int RoomId { get; set; }
        public string GuestName { get; set; }

        public long ContactNumber { get; set; } = 2557486853;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string Status  { get; set; }
    }
}
