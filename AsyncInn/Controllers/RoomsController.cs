using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Services;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository rooms;
        private readonly AsyncInnDbContext _context;

        public RoomsController(IRoomRepository rooms, AsyncInnDbContext context)
        {
            this.rooms = rooms;
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await rooms.GetAllRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            return await rooms.GetRoomById(id);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await rooms.Insert(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deleteSucceeded = await rooms.TryDelete(id);

            if (!deleteSucceeded)
            {
                return NotFound();
            }

            //_context.Hotels.Remove(hotel);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }


        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            //var amenity = await _context.Amenities.FindAsync(amenityId);
            //var room = await _context.Rooms.FindAsync(roomId);

            await rooms.AddAmenity(amenityId, roomId);
            return NoContent();


        }

        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            //var amenity = await _context.Amenities.FindAsync(amenityId);
            //var room = await _context.Rooms.FindAsync(roomId);

            await rooms.RemoveAmenity(amenityId, roomId);
            return NoContent();
        }
    }
}
