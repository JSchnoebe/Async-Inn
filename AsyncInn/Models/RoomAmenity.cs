using System;
namespace AsyncInn.Models
{
    public class RoomAmenity
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
    }
}
