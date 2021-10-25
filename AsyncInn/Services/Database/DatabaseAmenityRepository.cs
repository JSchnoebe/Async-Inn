using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Services.Database
{
    public class DatabaseAmenityRepository : IAmenityRepository
    {
        private readonly AsyncInnDbContext _context;

        public DatabaseAmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public Task<List<AmenityDTO>> GetAll()
        {
            return _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                   ID = amenity.Id,
                   Name = amenity.Name

                })
                .ToListAsync();
        }
    }
}
