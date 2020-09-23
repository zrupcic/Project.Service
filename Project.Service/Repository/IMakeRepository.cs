using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace Project.Service.Repository
{
    public interface IMakeRepository
    {
        Task<List<VehicleMake>> GetMakes(string sortOrder, string searchString);

        Task<int> AddMake(VehicleMake make);

        Task<int> DeleteMake(int? makeId);

        Task<int> UpdateMake(VehicleMake make);
    }
}