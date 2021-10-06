using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMirm.Models
{
    //JOIN TABLE
    public class HotelRoom
    {
        public Hotel Hotel { get; set; }

        public Room Room { get; set; }
    }
}
