using System;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options){}

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasData(
                new Hotel { Id = 1, Name = "Kalahari" },
                new Hotel { Id = 2, Name = "Wilderness" },
                new Hotel { Id = 3, Name = "Hilton" }
                );

            modelBuilder.Entity<Room>()
                .HasData(
                new Room { Id = 1, Name = "Studio", Layout = 0 },
                new Room { Id = 2, Name = "OneBedroom", Layout = 1 },
                new Room { Id = 3, Name = "TwoBedroom", Layout = 2 }
                );

            modelBuilder.Entity<Amenity>()
               .HasData(
               new Amenity { Id = 1, RoomId = 0 },
               new Amenity { Id = 2, RoomId = 1 },
               new Amenity { Id = 3, RoomId = 2 }
               );

            modelBuilder.Entity<RoomAmenity>()
                .HasKey(ra => new { ra.RoomId, ra.AmenityId });

            modelBuilder.Entity<RoomAmenity>()
                .HasData(
                new RoomAmenity { AmenityId = 1, RoomId = 0},
                new RoomAmenity { AmenityId = 2, RoomId = 1},
                new RoomAmenity { AmenityId = 3, RoomId = 2}
                );

            modelBuilder.Entity<HotelRoom>()
                .HasKey(hr => new { hr.RoomId, hr.HotelId });
                
        }

        public DbSet<AsyncInn.Models.HotelRoom> HotelRoom { get; set; }
    }
}
