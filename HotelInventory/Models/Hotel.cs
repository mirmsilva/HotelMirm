using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        //NAVIGATION
        public ICollection<Room> Rooms { get; set; }
    }
}
