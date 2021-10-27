﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models.DTOs
{
    public class RegisterUserDTO
    {
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}

