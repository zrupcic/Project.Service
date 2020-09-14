using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Service.DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("ProjectContext")
        { }
        public DbSet<VehicleModel> vehicleModels { get; set; }
        public DbSet<VehicleMake> vehicleMakes { get; set; }

    }
}