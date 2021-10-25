using System;
using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }
        public List<RoomAmenity> RoomAmenities { get; internal set; }
    }
}
