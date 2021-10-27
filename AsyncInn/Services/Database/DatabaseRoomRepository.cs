using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Controllers;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Services.Database
{
    public class DatabaseRoomRepository : IRoomRepository
    {
        private readonly AsyncInnDbContext _context;
        
        public DatabaseRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public Task AddAmenity(int amenityId, int roomId)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetAllRooms()
        {
            return await _context.Rooms

                .Include(r => r.RoomAmenities)

                .ThenInclude(ra => ra.Amenity)

                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.Name,
                    Layout = room.Layout,

                    Amenities = room.RoomAmenities
                    .Select(ra => new AmenityDTO
                    {
                        ID = ra.AmenityId,
                        Name = ra.Amenity.Name,
                    })
                    .ToList(),

                })

                .ToListAsync();
        }

        public async Task<ActionResult<RoomDTO>> GetRoomById(int id)
        {
            var result = await _context.Rooms

                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.Name
                })
                .FirstOrDefaultAsync(room => room.ID == id);

            return result;
        }

        public async Task Insert(Room rooms)
        {
            _context.Rooms.Add(rooms);
            await _context.SaveChangesAsync();
        }

        public Task RemoveAmenity(int amenityId, int roomId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TryDelete(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return false;
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }

        Task<ActionResult<IEnumerable<RoomDTO>>> IRoomRepository.GetAllRooms()
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<RoomDTO>> IRoomRepository.GetRoomById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
