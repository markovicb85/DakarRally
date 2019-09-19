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
    public class VehicleController : ApiController
    {

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
        [HttpGet]
        public List<VehicleModel> Get()
        {
            return VehicleDataLayer.GetAllVehicles();
        }


        //7. Get leaderboard for specific vehicle type: cars, trucks, motorcycles(parameters: type)
        //[Route("api/Vehicle/GetVehicleType/{model}")]
        //[HttpGet]
        // GET: api/Vehicle/GetVehicleType
        //public List<Vehicle> GetVehicleType(string model)
        //{
        //    //SQLiteDataAccess.LoadVehicles();
        //    return vehicles.Where(x => x.Model.Equals(model)).ToList();
        //}


        //8. Get vehicle statistics: distance, malfunction statistics, status, finish time(parameters: vehicle identifier)
        //[Route("api/Vehicle/GetVehicleStatistic/{id:int}")]
        //[HttpGet]
        // GET: api/Vehicle/GetVehicleStatistic
        //public Vehicle GetVehicleStatistic(int id)
        //{
        //    return vehicles.FirstOrDefault(v => v.Id == id);
        //}

    }
}
