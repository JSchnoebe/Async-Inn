using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Services
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAll();
        Task<Hotel> GetById(int id);
        Task Insert(Hotel hotels);
        Task<bool> TryDelete(int id);
    }
}