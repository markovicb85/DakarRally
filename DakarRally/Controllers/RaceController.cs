using DakarRally.Models;
using DakarRallyDataAccess.DataLayer;
using DakarRallyShared;
using DakarRallyShared.ModelShared;
using System;
using System.Collections.Generic;
using System.Web.Http;

/// <summary>
/// This controller holds methods for race 
/// </summary>
namespace DakarRally.Controllers
{
    public class RaceController : ApiController
    {
        //TODO Set all methods in Race Controller to return type HttpResponseMessage

        //1. Create race(parameters: year)
        /// <summary>
        /// Create race(parameters: year)
        /// </summary>
        /// <param name="race">Represent a race</param>
        /// <returns>Returns race</returns>
        [Route("api/Race/CreateRace")]
        [HttpPost]
        // POST: api/Race/CreateRace
        public RaceModel CreateRace([FromBody]RaceModel race)
        {   
            return RaceDataLayer.CreateRace(race);
        }

        //2. Add vehicle to the race(parameters: vehicle)
        /// <summary>
        /// Add vehicle to the race(parameters: vehicle)
        /// </summary>
        /// <param name="vehicle">Represent a vehicle</param>
        /// <returns>Return inserted vehicle</returns>
        [Route("api/Race/AddVehicleToRace")]
        [HttpPost]
        // POST api/Race/AddVehicleToRace
        public VehicleModel AddVehicleToRace([FromBody]VehicleModel vehicle)
        {
            return RaceDataLayer.AddVehicleToRace(vehicle);            
        }

        //4. Remove vehicle from the race: (parameters: vehicle identifier)
        /// <summary>
        /// Remove vehicle from the race: (parameters: vehicle identifier)
        /// </summary>
        /// <param name="id">The unique identifier for vehicle</param>
        [HttpDelete]
        // DELETE api/Race/5
        public void Delete(int id)
        {
            RaceDataLayer.DeleteVehicleFromTheRace(id);
        }

        //5. Start the race(parameters: race identifier)
        /// <summary>
        /// Start the race(parameters: race identifier)
        /// </summary>
        /// <param name="id">The unique identifier for race</param>
        [Route("api/Race/StartRace/{id:int}")]
        [HttpGet]
        public async void StartRace(int id)
        {
            await RaceDataLayer.StartRaceAsync(id);            
        }

        //10. Get race status that includes: race status(pending, running, finished), number of vehicles grouped by  vehicle status, number of vehicles grouped by vehicle type(parameters: race identifier)
        /// <summary>
        /// Get race status that includes: race status(pending, running, finished), number of vehicles grouped by  vehicle status, number of vehicles grouped by vehicle type(parameters: race identifier)
        /// </summary>
        /// <param name="id">The unique identifier for race</param>
        /// <returns></returns>
        [Route("api/Race/RaceStatus/{id:int}")]
        [HttpGet]
        // GET api/Race/RaceStatus/1
        public RaceStatisticModel RaceStatus(int id)
        {
            return RaceDataLayer.GetRaceStatus(id);
        }
    }
}
