using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Services
{
    public interface IRoomRepository
    {
        Task<ActionResult<IEnumerable<RoomDTO>>> GetAllRooms();
        Task<ActionResult<RoomDTO>> GetRoomById(int id);
        Task Insert(Room rooms);
        Task<bool> TryDelete(int id);
        Task AddAmenity(int amenityId, int roomId);
        Task RemoveAmenity(int amenityId, int roomId);
    }
}
