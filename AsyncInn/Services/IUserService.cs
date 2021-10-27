using System;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AsyncInn.Services
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Authenticate(string username, string password);
    }
}
