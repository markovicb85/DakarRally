using DakarRallyShared;
using DakarRallyShared.ModelShared;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DakarRallyDataAccess.DataLayer
{
    public class RaceDataLayer
    {
        private static string sql;

        public static RaceModel CreateRace(RaceModel race)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                sql = @"insert into racetable (RaceStatus, Distance, Year)
                        values( @RaceStatus, @Distance, @Year)";
                con.Execute(sql, race);

                return con.Query<RaceModel>("SELECT * FROM racetable").LastOrDefault();
            }

        }

        public static VehicleModel AddVehicleToRace(VehicleModel vehicle)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                //TODO Check if race exist and get RaceId, if not show the message 

                sql = @"insert into vehicletable(TeamName, Model, ManufacturingDate, Speed, LightMalFun, HeavyMalFun, RaceId) 
                        values(@TeamName, @Model, @ManufacturingDate, @Speed, @LightMalFun, @HeavyMalFun, @RaceId)";
                con.Execute(sql, vehicle);

                return con.Query<VehicleModel>("SELECT * FROM vehicletable").LastOrDefault();
            }

        }

        public static void DeleteVehicleFromTheRace(int id)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                sql = @"delete from vehicletable where VehicleId = @VehicleId";                        
                var result = con.Execute(sql, new {VehicleId = id });
            }

        }

    }
}
