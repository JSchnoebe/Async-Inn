using System;
using System.Threading.Tasks;

namespace AsyncInn.Services
{
    public interface IHotelRoomRepository
    {
        Task RemoveRoom(int roomId, int hotelId);
    }
}
