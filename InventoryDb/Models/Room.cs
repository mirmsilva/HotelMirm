using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryDb.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int AmenityID { get; set; }


        //NAVIGATION
        public Hotel Hotel { get; set; }
        public Amenity Amenity { get; set; }

        
    }
}
