using InventoryDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryDb.Data
{
    public static class DbInitializer
    {
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
        }
    }
}
