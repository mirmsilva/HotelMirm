using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Models
{
    public class RoomAmenity
    {
        public int RoomID { get; set; }
        public int AmenityID { get; set; }

        //NAVIGATION
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
        

    }
}
