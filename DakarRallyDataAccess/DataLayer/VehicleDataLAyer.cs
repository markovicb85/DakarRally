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

#region VehicleController Method
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
                con.Open();

                using (IDbTransaction tran = con.BeginTransaction())
                {                
                    sql = @"UPDATE vehicletable
                            SET TeamName = @TeamName,
                            Model = @Model,
                            ManufacturingDate = @ManufacturingDate, 
                            Speed = @Speed, 
                            LightMalFun = @LightMalFun, 
                            HeavyMalFun = @HeavyMalFun,
                            MalfunctionTime = @MalfunctionTime,
                            RaceId = @RaceId,
                            Distance = @Distance,
                            VehicleStatus = @VehicleStatus,
                            Time = @Time
                            WHERE VehicleId = @VehicleId";
                    con.Execute(sql, vehicle);

                    tran.Commit();
                    return con.Query<VehicleModel>("SELECT * FROM vehicletable").LastOrDefault();
                }
            }

        }
#endregion VehicleController Method

    }
}
