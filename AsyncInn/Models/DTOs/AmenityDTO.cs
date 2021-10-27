using System;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models.DTOs
{

    public class AmenityDTO
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
