using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Controllers;
using AsyncInn.Data;
using AsyncInn.Models;
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

        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return null;
            }

            return room;
        }

        public async Task Insert(Room rooms)
        {
            _context.Rooms.Add(rooms);
            await _context.SaveChangesAsync();
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
    }
}
