using DakarRallyShared.Enums;
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
                //TODO This need to be checked! When using transaction and opening connection is sometimes happened to get the error "No such a table"
                SQLiteDataAccess.InstanceDB();
                //con.Open();

                //using (IDbTransaction tran = con.BeginTransaction())
                //{                
                    sql = @"UPDATE vehicletable
                            SET TeamName = @TeamName,
                            Model = @Model,
                            Type = @Type,
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

                    //tran.Commit();
                    return con.Query<VehicleModel>("SELECT * FROM vehicletable").LastOrDefault();
                //}
            }

        }

        public static List<LeaderboardModel> GetLeaderboard(string type = null)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                LeaderboardModel vehicleData = new LeaderboardModel();
                List<LeaderboardModel> result = new List<LeaderboardModel>();
                var allVehicles = con.Query<VehicleModel>("SELECT * FROM vehicletable").ToList();

                if (!string.IsNullOrEmpty(type))
                {
                    allVehicles.RemoveAll(x => !x.Model.Equals(type));
                }

                foreach (VehicleModel v in allVehicles)
                {
                    vehicleData = new LeaderboardModel();
                    vehicleData.VehicleName = v.TeamName;
                    vehicleData.VehicleType = v.Model;
                    vehicleData.Distance = v.Distance;
                    vehicleData.Time = v.Time;
                    vehicleData.Status = v.VehicleStatus;
                    result.Add(vehicleData);
                }
                return result; 
            }

        }

        public static VehicleStatisticModel GetVehicleStatistic(int id)
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                VehicleStatisticModel vehicleStat = new VehicleStatisticModel();
                var vehicle = con.Query<VehicleModel>("SELECT * FROM vehicletable").FirstOrDefault(v => v.VehicleId == id);
                vehicleStat.Distance = vehicle.Distance;
                if (vehicle.VehicleStatus < (int)Enums.VehicleStatus.finishRace)
                {
                    vehicleStat.Malfunction = vehicle.VehicleStatus;
                }
                else
                {
                    vehicleStat.Status = vehicle.VehicleStatus;
                }
                vehicleStat.Time = vehicle.Time;

                return vehicleStat;
            }

        }

        public static void UpdateVehicleStatus()
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                VehicleStatisticModel vehicleStat = new VehicleStatisticModel();
                con.Query<VehicleModel>("UPDATE vehicletable SET VehicleStatus = 0");       
            }

        }

        public static List<VehicleModel> GetFilteredVehicles(string team, int? status,  int? distance, string Models = "", string date = "")
        {
            using (IDbConnection con = new SQLiteConnection(SQLiteDataAccess.GetConnectionString()))
            {
                SQLiteDataAccess.InstanceDB();

                string sql = @"SELECT * FROM vehicletable
                               WHERE TeamName = @TeamName
                               AND (@Model = '' or Model = @Model)
                               AND (@ManufacturingDate = '' or ManufacturingDate = @ManufacturingDate)
                               AND (@VehicleStatus = '' or VehicleStatus = @VehicleStatus)
                               AND (@Distance = '' or Distance = @Distance)";

                return con.Query<VehicleModel>(sql , new{ Model = Models ?? "", ManufacturingDate = date ?? "", VehicleStatus = status ?? null, Distance = distance ?? null}).ToList(); ;
            }

        }

        #endregion VehicleController Method

    }
}
