using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project.Service.Repository
{
    public class ModelRepository : IModelRepository
    {
        private VehicleContext db;

        public ModelRepository(VehicleContext _db)
        {
            db = _db;
        }

        public async Task<int> AddModel(VehicleModel model)
        {
            if (db != null)
            {
                db.vehicleModels.Add(model);
                await db.SaveChangesAsync();

                return model.ID;
            }

            return 0;
        }

        public async Task<int> DeleteModel(int? modelId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var model = await db.vehicleModels.FirstOrDefaultAsync(x => x.ID == modelId);

                if (model != null)
                {
                    //Delete that model
                    db.vehicleModels.Remove(model);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<VehicleModel>> GetModels()
        {
            if (db != null)
            {
                return await db.vehicleModels.ToListAsync();
            }

            return null;
        }

        public async Task<int> UpdateModel(VehicleModel model)
        {
            if (db != null)
            {
                //Update that model
                //db.vehicleModels.Update(model);
                db.Entry(model).State = EntityState.Modified;

                //Commit the transaction
                await db.SaveChangesAsync();
                return model.ID;
            }
            return 0;
        }
    }
}