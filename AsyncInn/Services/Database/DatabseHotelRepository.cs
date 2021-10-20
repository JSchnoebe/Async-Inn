using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Services.Database
{
    public class DatabaseHotelRepository : IHotelRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseHotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAll()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetById(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task Insert(Hotel hotels)
        {
            _context.Hotels.Add(hotels);
            await _context.SaveChangesAsync();
        }
    }
}