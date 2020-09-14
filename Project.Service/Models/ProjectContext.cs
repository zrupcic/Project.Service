using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Service.Models
{
    public class ProjectContext : DbContext
    {

        public DbSet<VehicleMake> vehicleMakes { get; set; }
        public DbSet<VehicleModel> vehicleModels { get; set; }
    }
}