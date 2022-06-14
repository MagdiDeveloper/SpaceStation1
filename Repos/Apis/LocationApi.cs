using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Tools.Communication;

namespace Repos.Apis
{
    public class LocationApi
    {
        private static string baseUrl = WebConfigurationManager.AppSettings["open-notify.api.baseUrl"];
        private static string locationApi = WebConfigurationManager.AppSettings["open-notify.api.location"];

        public static Response<Location> GetCurrentLocation()
        {
            Response<Location> response = new Response<Location>();
            string getCurrentLocationApi = string.Concat(baseUrl, locationApi);
            var result = Tools.Connections.RestConnection.Get<LocationApiReponse>(getCurrentLocationApi);
            if (result != null && result.message == "success")
            {
                response.Message = result.message;
                response.IsSuccess = true;
                float longitude = 0;
                float latitude = 0;
                response.Result = new Location();
                if (float.TryParse(result.iss_position?.longitude, out longitude))
                {
                    response.Result.Longitude = longitude;
                }
                if (float.TryParse(result.iss_position?.latitude, out latitude))
                {
                    response.Result.Latitude = latitude;
                }
                response.Result.CurrentTime = new TimeSpan(result.timestamp);


            }
            return response;
        }
    }
}
