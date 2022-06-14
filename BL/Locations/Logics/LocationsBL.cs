using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Locations.Logics
{
    public class LocationsBL
    {
        public bool AddLocation(Location myLocation)
        {
            using (var database = new DAL.Context.SpaceLocationContext())
            {
                var newLocation = new DAL.Domains.Location
                {
                    Notes = myLocation.Notes,
                    Latitude = myLocation.Latitude,
                    Longitude = myLocation.Longitude,
                };
                database.Locations.Add(newLocation);
                return database.SaveChanges() > 0;

            }
        }
        public List<Location> GetLocations()
        {
            using (var database = new DAL.Context.SpaceLocationContext())
            {
                return database.Locations.Select(l => new Location
                {
                    Latitude = l.Latitude,
                    Longitude = l.Longitude,
                    Notes = l.Notes,
                }).ToList();


            }
        }
    }
}
