using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Apis
{
    public class LocationApiReponse
    {
        public string message { get; set; }
        public iss_position iss_position { get; set; }
        public long timestamp { get; set; }
     }
    public class iss_position
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

}
