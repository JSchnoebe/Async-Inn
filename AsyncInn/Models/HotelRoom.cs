using System;
namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
    }
}
