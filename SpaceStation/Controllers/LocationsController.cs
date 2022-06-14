using SpaceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SpaceStation.Controllers
{
    [EnableCors("*","*","*")]
    [RoutePrefix("api/Locations")]
    public class LocationsController : ApiController
    {
        // GET api/values
        [Route("Current")]
        public HttpResponseMessage GetCurrentLocation()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                new
                {
                    Data = Repos.Apis.LocationApi.GetCurrentLocation()
                });
        }


        [Route("List")]
        public HttpResponseMessage GetMyLocations()
        {
            BL.Locations.Logics.LocationsBL locationsBL = new BL.Locations.Logics.LocationsBL();
            var locations = locationsBL.GetLocations();
            return Request.CreateResponse(HttpStatusCode.OK,
               new
               {
                   Data = locations
               });
        }

        // POST api/values
        [Route("Save")]
        public HttpResponseMessage Post([FromBody] LocationForm model)
        {
            BL.Locations.Logics.LocationsBL locationsBL = new BL.Locations.Logics.LocationsBL();
            bool result = locationsBL.AddLocation(
                new BE.Location
                { Latitude = model.Latitude, Longitude = model.Longitude, Notes = model.Notes });
            return Request.CreateResponse(HttpStatusCode.OK,
            new
            {
                Data = result
            });
        }
    }
}
