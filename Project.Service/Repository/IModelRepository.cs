using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Repository
{
    interface IModelRepository
    {

        Task<List<VehicleModel>> GetModels(string sortOrder, string searchString);

        Task<int> AddModel(VehicleModel model);

        Task<int> DeleteModel(int? modelId);

        Task<int> UpdateModel(VehicleModel model);
    }
}
