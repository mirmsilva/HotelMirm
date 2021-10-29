using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }


        //NAVIGATION
        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenity>RoomAmenities { get; set; }
        //Many-to-many and one-to-many navigation relationships can contain multiple entities. When ICollection<T> is used, EF creates a HashSet<T> collection by default
    }
}
