using DAL.Domains;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Context
{
    public class SpaceLocationContext : DbContext
    {
        // Your context has been configured to use a 'SpaceLocationContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.Context.SpaceLocationContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SpaceLocationContext' 
        // connection string in the application configuration file.
        public SpaceLocationContext()
            : base("name=SpaceLocationContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Location> Locations { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}