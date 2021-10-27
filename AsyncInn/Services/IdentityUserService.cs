using System;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AsyncInn.Services
{
    public class IdentityUserService : IUserService
    {
        public Task<UserDTO> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }

    }
}
