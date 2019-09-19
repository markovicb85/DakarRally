using DakarRallyShared.ModelShared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyDataAccess.DataLayer
{
    public class VehicleDataLayer
    {
        private static string sql;

        public static List<VehicleModel> GetAllVehicles()
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();
                return con.Query<VehicleModel>("SELECT * FROM vehicletable").ToList();
            }

        }

        public static VehicleModel UpdateVehicle(VehicleModel vehicle)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                sql = @"update vehicletable
                        set TeamName = @TeamName,
                        Model = @Model,
                        ManufacturingDate = @ManufacturingDate, 
                        Speed = @Speed, 
                        LightMalFun = @LightMalFun, 
                        HeavyMalFun = @HeavyMalFun, 
                        RaceId = @RaceId
                        where VehicleId = @VehicleId";
                con.Execute(sql, vehicle);

                return con.Query<VehicleModel>("SELECT * FROM vehicletable").LastOrDefault();
            }

        }

    }
}
