using InventoryDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryDb.Data
{
    public static class DbInitializer
    {
        //This will check if a db exists if it does it will do nothing. If it doesn't it will load it with the test data below.
        public static void Initialize( InventoryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Hotels.Any())
            {
                return;
            }

            var hotels = new Hotel[]
            {
                new Hotel{ Name="City Explorer", City="Seattle", State="WA"},
                new Hotel{ Name="Pearl Inn", City="Portland", State="OR"},
            };
            foreach (Hotel h in hotels)
            {
                context.Hotels.Add(h);
            }
            context.SaveChanges();

            var amenities = new Amenity[]
            {
                new Amenity{ID=1, Type = "Microwave" },
                new Amenity{ID=2, Type = "Coffee Maker" },
                new Amenity{ID=3, Type = "Fridge" },
            };
            foreach(Amenity a in amenities)
            {
                context.Amenities.Add(a);
            }
            context.SaveChanges();

            var rooms = new Room[]
            {
                new Room{HotelID=1, AmenityID=1},
                new Room{HotelID=1, AmenityID=2},
                new Room{HotelID=2, AmenityID=1},
                new Room{HotelID=2, AmenityID=3},
            };
            foreach(Room r in rooms)
            {
                context.Rooms.Add(r);
            }
            context.SaveChanges();
        }
    }
}
