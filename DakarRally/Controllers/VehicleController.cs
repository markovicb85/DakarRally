using DakarRally.Models;
using DakarRallyDataAccess.DataLayer;
using DakarRallyShared.ModelShared;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DakarRally.Controllers
{
    /// <summary>
    /// This controller holds methods for vehicle 
    /// </summary>
    public class VehicleController : ApiController
    {
        //TODO Set all methods in Vehicle Controller to return type HttpResponseMessage

        /// <summary>
        /// Update vehicle
        /// </summary>
        /// <param name="vehicle">Unique vehicle</param>
        /// <returns>This method update the vehicle and returns the new one.</returns>
        //3. Update vehicle info(parameters: vehicle)
        [Route("api/Vehicle/UpdateVehicle")]
        [HttpPut]
        // PUT api/Vehicle/UpdateVehicle
        public VehicleModel UpdateVehicle([FromBody]VehicleModel vehicle)
        {
            return VehicleDataLayer.UpdateVehicle(vehicle);
        }

        //TODO Order by position in race
        // GET: api/Vehicle
        /// <summary>
        /// This method returns the list of all vehicles
        /// </summary>
        /// <returns>List of all vehicles</returns>
        [HttpGet]
        public List<VehicleModel> Get()
        {
            return VehicleDataLayer.GetAllVehicles();
        }

        //6. Get leaderboard including all vehicles
        /// <summary>
        /// Get leaderboard including all vehicles
        /// </summary>
        /// <returns>Returs leaderboards statistics</returns>
        [Route("api/Vehicle/GetLeaderboard")]
        [HttpGet]
        // GET: api/Vehicle/GetLeaderboard
        public List<LeaderboardModel> GetLeaderboard()
        {
            return VehicleDataLayer.GetLeaderboard();
        }


        //7. Get leaderboard for specific vehicle type: cars, trucks, motorcycles(parameters: type)
        /// <summary>
        /// Get leaderboard for specific vehicle type: cars, trucks, motorcycles(parameters: type)
        /// </summary>
        /// <param name="type">Type of vehicle</param>
        /// <returns>Returns leaderboard</returns>
        [Route("api/Vehicle/GetLeaderboard/{type}")]
        [HttpGet]
        // GET: api/Vehicle/GetLeaderboard
        public List<LeaderboardModel> GetLeaderboard(string type)
        {
            return VehicleDataLayer.GetLeaderboard(type);
        }


        //8. Get vehicle statistics: distance, malfunction statistics, status, finish time(parameters: vehicle identifier)
        /// <summary>
        /// Get vehicle statistics: distance, malfunction statistics, status, finish time(parameters: vehicle identifier)
        /// </summary>
        /// <param name="vehicleId">The unique identifier for vehicle</param>
        /// <returns>Returns vehicle statistic</returns>
        [Route("api/Vehicle/GetVehicleStatistic/{vehicleId:int}")]
        [HttpGet]
        // GET: api/Vehicle/GetLeaderboard/1
        public VehicleStatisticModel GetVehicleStatistic(int vehicleId)
        {
            return VehicleDataLayer.GetVehicleStatistic(vehicleId);
        }

        //9. Find vehicle(s) (parameters: team AND/OR model AND/OR manufacturing date AND/OR status AND/OR distance, sort order)
        /// <summary>
        /// Find vehicle(s) (parameters: team AND/OR model AND/OR manufacturing date AND/OR status AND/OR distance, sort order)
        /// </summary>
        /// <param name="team">Represent team name</param>
        /// <param name="status">Option value for status</param>
        /// <param name="distance">Option value for distance</param>
        /// <param name="models">Option value for models</param>
        /// <param name="date">Option value for date</param>
        /// <returns>Filtered list of all vehicle</returns>
        [Route("api/Vehicle/GetFilteredVehicles/{team}/{status:int}/{distance:int}/{model}/{date}")]
        [HttpGet]
        // GET: api/Vehicle/GetLeaderboard/1
        public List<VehicleModel> GetFilteredVehicles(string team, int status, int distance, string models, string date)
        {
            return VehicleDataLayer.GetFilteredVehicles(team, status, distance, models, date);
        }
    }
}
