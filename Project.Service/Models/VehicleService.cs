using Project.Service.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Project.Service.Models
{
    public class VehicleService : IMakeRepository, IModelRepository
    {
        private VehicleContext db;

        public VehicleService(VehicleContext _db)
        {
            db = _db;
        }

        public async Task<int> AddMake(VehicleMake make)
        {
            if (db != null)
            {
                db.vehicleMakes.Add(make);
                await db.SaveChangesAsync();

                return make.ID;
            }

            return 0;
        }

        public async Task<int> DeleteMake(int? makeId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var make = await db.vehicleMakes.FirstOrDefaultAsync(x => x.ID == makeId);

                if (make != null)
                {
                    //Delete that model
                    db.vehicleMakes.Remove(make);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<VehicleMake>> GetMakes(string sortOrder, string searchString)
        {
            if (db != null)
            {
                var makes = from m in db.vehicleMakes select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    makes = makes.Where(s => s.Name.Contains(searchString)
                                           || s.Abrv.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        makes = makes.OrderByDescending(m => m.Name);
                        break;
                    case "abrv":
                        makes = makes.OrderBy(m => m.Abrv);
                        break;
                    case "abrv_desc":
                        makes = makes.OrderByDescending(m => m.Abrv);
                        break;
                    default:
                        makes = makes.OrderBy(m => m.Name);
                        break;
                }
                return await makes.ToListAsync();
            }

            return null;
        }

        public async Task<int> UpdateMake(VehicleMake make)
        {
            if (db != null)
            {
                //Update that model
                //db.vehicleModels.Update(model);
                db.Entry(make).State = EntityState.Modified;

                //Commit the transaction
                await db.SaveChangesAsync();
                return make.ID;
            }
            return 0;
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

        public async Task<List<VehicleModel>> GetModels(string sortOrder, string searchString)
        {
            if (db != null)
            {
                var models = from m in db.vehicleModels select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    models = models.Where(s => s.Name.Contains(searchString)
                                           || s.Abrv.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        models = models.OrderByDescending(m => m.Name);
                        break;
                    case "abrv":
                        models = models.OrderBy(m => m.Abrv);
                        break;
                    case "abrv_desc":
                        models = models.OrderByDescending(m => m.Abrv);
                        break;
                    case "make":
                        models = models.OrderBy(m => m.VehicleMake.Name);
                        break;
                    case "make_desc":
                        models = models.OrderByDescending(m => m.VehicleMake.Name);
                        break;
                    default:
                        models = models.OrderBy(m => m.Name);
                        break;
                }
                return await models.ToListAsync();
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