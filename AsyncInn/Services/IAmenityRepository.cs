using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Services
{
    public interface IAmenityRepository
    {
        Task<List<AmenityDTO>> GetAll();
        Task<AmenityDTO> GetById(int id);
    }
}
