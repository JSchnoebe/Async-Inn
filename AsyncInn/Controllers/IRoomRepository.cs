using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Controllers
{
    public interface IRoomRepository
    {
        Task<ActionResult<IEnumerable<Room>>> GetAllRooms();
        Task<ActionResult<Room>> GetRoomById(int id);
    }
}
