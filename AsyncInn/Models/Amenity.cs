using System;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
