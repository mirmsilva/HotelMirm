using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace HotelMirm.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int BaseCost { get; set; }
        public HotelRoom HotelRoom {get; set;}
    }
}
