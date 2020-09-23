using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Service.Models
{
    public partial class VehicleContext : DbContext
    {
        public VehicleContext() : base("ProjectContext")
        { }
        public virtual DbSet<VehicleModel> vehicleModels { get; set; }
        public virtual DbSet<VehicleMake> vehicleMakes { get; set; }

    }
}