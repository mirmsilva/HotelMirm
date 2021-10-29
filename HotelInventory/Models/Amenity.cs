using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Models
{
    public class Amenity
    {
        public int AmenityID { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }

        //NAVIGATION
        //one amenity can be assigned to multiple rooms
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
    }
}
