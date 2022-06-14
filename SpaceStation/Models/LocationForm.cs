using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceStation.Models
{
    public class LocationForm
    {
        [Required]
        public float Longitude { get; set; }
        [Required]
        public float Latitude { get; set; }
        public TimeSpan CurrentTime { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}