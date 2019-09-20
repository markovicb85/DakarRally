using DakarRally.Models;
using DakarRallyDataAccess.DataLayer;
using DakarRallyShared;
using DakarRallyShared.ModelShared;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DakarRally.Controllers
{
    public class RaceController : ApiController
    {
        //1. Create race(parameters: year)
        [Route("api/Race/CreateRace")]
        [HttpPost]
        // POST: api/Race/CreateRace
        public RaceModel CreateRace([FromBody]RaceModel race)
        {   
            //Upisati trku u bazu, dodati auto id za trku i vozilo
            return RaceDataLayer.CreateRace(race);
        }

        //2. Add vehicle to the race(parameters: vehicle)
        [Route("api/Race/AddVehicleToRace")]
        [HttpPost]
        // POST api/Race/AddVehicleToRace
        public VehicleModel AddVehicleToRace([FromBody]VehicleModel vehicle)
        {
            return RaceDataLayer.AddVehicleToRace(vehicle);            
        }

        //4. Remove vehicle from the race: (parameters: vehicle identifier)
        [HttpDelete]
        // DELETE api/Race/5
        public void Delete(int id)
        {
            RaceDataLayer.DeleteVehicleFromTheRace(id);
        }

        //5. Start the race(parameters: race identifier)
        [Route("api/Race/StartRace/{id:int}")]
        [HttpGet]
        public async void StartRace(int id)
        {
            await RaceDataLayer.StartRaceAsync(id);            
        }

        //6. Get leaderboard including all vehicles

        //10. Get race status that includes: race status(pending, running, finished), number of vehicles grouped by  vehicle status, number of vehicles grouped by vehicle type(parameters: race identifier)

    }
}
