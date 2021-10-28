using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Services
{
    public interface IHotelRepository
    {
        Task<List<HotelDTO>> GetAll();
        Task<HotelDTO> GetById(int id);
        Task Insert(Hotel hotels);
        Task<bool> TryDelete(int id);
    }
}