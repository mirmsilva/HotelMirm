using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Models
{
    public class HotelRoom
    {
        public int HotelRoomID { get; set; }
        public int HotelID { get; set; }
        public int RoomID { get; set; }

        //NAVIGATION
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        
    }
}
