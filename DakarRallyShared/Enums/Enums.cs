using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyShared.Enums
{
    public class Enums
    {
        public enum RaceStatus
        {
            pending = 0,
            running = 1,
            finished = 2
        }

        public enum VehicleStatus
        {
            good = 0,
            lightMalFun = 1,
            heavyMalFun = 2,
            finishRace = 3
        }

        public enum VehicleType
        {
            sportsCar = 1,
            terrainCar = 2,
            sportMotorcycle = 3,
            crossMotorcycle = 4,
            truck = 5
        }
    }
}
