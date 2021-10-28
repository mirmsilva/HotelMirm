using HotelInventory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelInventory.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        //Room & Amenities could be omitted & would still be acessible because they are referenced in the models


        //This code block overwrites the name of the tables created. For example: Hotels to Hotel
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<HotelRoom>().ToTable("HotelRoom");
            modelBuilder.Entity<Amenity>().ToTable("Amenity");

        }
    }
}
