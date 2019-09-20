using DakarRallyShared.ModelShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyShared
{
    public class RaceModel
    {

        private int raceID;
        private int raceStatus;
        private int distance = 10000;
        private int year;
        private int numberByVehicleStatus;
        private int numberByVehicleType;

        public RaceModel()
        {
        }

        public RaceModel(int raceID, int raceStatus, int distance, int year, int numberByVehicleStatus, int numberByVehicleType)
        {
            this.RaceID = raceID;
            this.RaceStatus = raceStatus;
            this.Distance = distance;
            this.Year = year;
            this.NumberByVehicleStatus = numberByVehicleStatus;
            this.NumberByVehicleType = numberByVehicleType;
        }

        public int RaceID { get => raceID; set => raceID = value; }
        public int RaceStatus { get => raceStatus; set => raceStatus = value; }
        public int Distance { get => distance; set => distance = value; }
        public int Year { get => year; set => year = value; }
        public int NumberByVehicleStatus { get => numberByVehicleStatus; set => numberByVehicleStatus = value; }
        public int NumberByVehicleType { get => numberByVehicleType; set => numberByVehicleType = value; }
    }
}
