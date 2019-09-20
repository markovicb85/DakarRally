using DakarRallyShared;
using DakarRallyShared.Enums;
using DakarRallyShared.ModelShared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DakarRallyDataAccess.DataLayer
{
    public class RaceDataLayer
    {
        private static string sql;

    #region RaceController Method

        public static RaceModel CreateRace(RaceModel race)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                sql = @"INSERT INTO racetable (RaceStatus, Distance, Year)
                        VALUES( @RaceStatus, @Distance, @Year)";
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

                sql = @"INSERT INTO vehicletable(TeamName, Model, ManufacturingDate, Speed, LightMalFun, HeavyMalFun, MalfunctionTime, RaceId, Distance, VehicleStatus, Time) 
                        VALUES(@TeamName, @Model, @ManufacturingDate, @Speed, @LightMalFun, @HeavyMalFun, @MalfunctionTime, @RaceId, @Distance, @VehicleStatus, @Time)";
                con.Execute(sql, vehicle);

                return con.Query<VehicleModel>("SELECT * FROM vehicletable").LastOrDefault();
            }

        }

        public static void DeleteVehicleFromTheRace(int id)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                sql = @"DELETE FROM vehicletable WHERE VehicleId = @VehicleId";                        
                var result = con.Execute(sql, new {VehicleId = id });
            }

        }


    #endregion RaceController Method

    #region Race simulations 
        public static async Task StartRaceAsync(int id)
        {
            SQLiteDataAccess.InstanceDB();

            var race = GetRace(id);
            race.RaceStatus = (int)Enums.RaceStatus.running;
            UpdateRace(race);
            
            List<VehicleModel> allVehicle = VehicleDataLayer.GetAllVehicles();
            List<Task<VehicleModel>> tasks = new List<Task<VehicleModel>>(); 

            foreach (var v in allVehicle)
            {
                tasks.Add(Task.Run(() => VehicleStartRace(v)));
            }

            var raceResult = await Task.WhenAll(tasks);
            race.RaceStatus = (int)Enums.RaceStatus.finished;
            UpdateRace(race);

        }

        private static VehicleModel VehicleStartRace(VehicleModel vehicle)
        {
            int i = 1;
            int totalDistance = 10000;
            Random random = new Random();
            var stopWatc = System.Diagnostics.Stopwatch.StartNew();

            while (vehicle.Distance <= totalDistance)
            {
                // 1h is equal 1s in simulation
                var randomNum = random.Next(1, 101);
                vehicle.Distance = i * vehicle.Speed;
                

                if (randomNum <= vehicle.HeavyMalFun)
                {
                    vehicle.VehicleStatus = (int)Enums.VehicleStatus.heavyMalFun;                    
                }
                else if(randomNum > vehicle.HeavyMalFun && randomNum <= (vehicle.LightMalFun + vehicle.HeavyMalFun))
                {
                    vehicle.VehicleStatus = (int)Enums.VehicleStatus.lightMalFun;
                }

                //Update vehicle data
                vehicle.Time = (stopWatc.ElapsedMilliseconds / 1000).ToString();
                VehicleDataLayer.UpdateVehicle(vehicle);

                if(vehicle.VehicleStatus == (int)Enums.VehicleStatus.heavyMalFun)
                {
                    break;                    
                }
                else if(vehicle.VehicleStatus == (int)Enums.VehicleStatus.lightMalFun)
                {
                    Thread.Sleep(vehicle.MalfunctionTime * 1000);
                    vehicle.VehicleStatus = (int)Enums.VehicleStatus.good;
                    VehicleDataLayer.UpdateVehicle(vehicle);
                }
                else
                {
                    VehicleDataLayer.UpdateVehicle(vehicle);
                    Thread.Sleep(1000);
                }

                if (vehicle.Distance >= totalDistance)
                {
                    vehicle.VehicleStatus = (int)Enums.VehicleStatus.finishRace;
                    vehicle.Time = (stopWatc.ElapsedMilliseconds / 1000).ToString();
                    VehicleDataLayer.UpdateVehicle(vehicle);
                    break;
                }

                i++;
            }

            return vehicle;

        }
        #endregion Race simulations


        private static RaceModel UpdateRace(RaceModel race)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                sql = @"UPDATE racetable
                        SET RaceStatus = @RaceStatus,
                        Distance = @Distance,
                        Year = @Year
                        WHERE RaceId = @RaceId";
                con.Execute(sql, race);

                return con.Query<RaceModel>("SELECT * FROM racetable").LastOrDefault();
            }

        }

        private static RaceModel GetRace(int id)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                sql = @"SELECT * FROM racetable";
                con.Execute(sql);

                return con.Query<RaceModel>("SELECT * FROM racetable").LastOrDefault(x => x.RaceID == id);
            }

        }

    }
}
