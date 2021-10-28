using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Identity;
using AsyncInn.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO data)
        {
            var user = await userService.Register(data, this.ModelState);

            if (user == null)
                return BadRequest(new ValidationProblemDetails(ModelState));

            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data);

            if (user == null)
                return Unauthorized();

            return user;
        }
    }

    
}