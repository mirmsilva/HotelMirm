using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Models
{
    public class Amenity
    {
        public int ID { get; set; }
        public string Type { get; set; }

        //NAVIGATION
        public ICollection<Room> Rooms { get; set; }

        //Many-to-many and one-to-many navigation relationships can contain multiple entities. When ICollection<T> is used, EF creates a HashSet<T> collection by default
    }
}
