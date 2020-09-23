using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project.Service.Repository
{
    public class MakeRepository : IMakeRepository
    {
        private VehicleContext db;

        public MakeRepository(VehicleContext _db)
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

        public async Task<List<VehicleMake>> GetMakes()
        {
            if (db != null)
            {
                return await db.vehicleMakes.ToListAsync();
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
    }
}