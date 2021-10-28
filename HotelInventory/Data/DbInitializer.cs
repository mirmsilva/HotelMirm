using HotelInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Data
{
    public class DbInitializer
    {
        //This will check if a db exists if it does it will do nothing. If it doesn't it will load it with the test data below.
        public static void Initialize(InventoryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Hotels.Any())
            {
                return;
            }
            //HOTEL
            var hotels = new Hotel[]
            {
                new Hotel{Name="City Suites", City="Seattle", State="WA"},
                new Hotel{Name="Pearl Inn", City="Portland", State="OR"},
                new Hotel{Name="Bay Hotel", City="San Francisco", State="CA"},
            };
            foreach (Hotel h in hotels)
            {
                context.Hotels.Add(h);
            }
            context.SaveChanges();

            //ROOMS
            var rooms = new Room[]
            {
                new Room{RoomID=102, Type="Suite", Floor=2},
                new Room{RoomID=201, Type="Studio", Floor=3},
            };
            foreach (Room r in rooms)
            {
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            //HOTELROOMS
            var hotelRooms = new HotelRoom[]
            {
                new HotelRoom{HotelID=1, RoomID=201},
                new HotelRoom{HotelID=2, RoomID=102},
            };
            foreach(HotelRoom hr in hotelRooms)
            {
                context.HotelRooms.Add(hr);
            }
            context.SaveChanges();

            //AMENITIES
            var amenities = new Amenity[]
            {
                new Amenity{Type="Microwave"},
                new Amenity{Type="Coffee Maker"},
                new Amenity{Type="Fridge"},
            };
            foreach (Amenity a in amenities)
            {
                context.Amenities.Add(a);
            }
            context.SaveChanges();
        }
    }
}
