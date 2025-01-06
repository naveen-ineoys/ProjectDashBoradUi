namespace ProjectUi.Models
{
    public class GuestModel
    {
     
        
        public int RoomId { get; set; }
        public string GuestName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string Status  { get; set; }
    }
}
