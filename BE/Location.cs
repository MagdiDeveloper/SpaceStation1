using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Location
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public TimeSpan CurrentTime { get; set; }
        public string Notes { get; set; }
    }
}
