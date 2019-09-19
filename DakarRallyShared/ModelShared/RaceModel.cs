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
        private string raceStatus;
        private int distance = 10000;
        private int year;
        private int numberByVehicleStatus;
        private int numberByVehicleType;
        private List<VehicleModel> allVehicle;

        public RaceModel()
        {
        }

        public RaceModel(int raceID, string raceStatus, int distance, int year, int numberByVehicleStatus, int numberByVehicleType, List<VehicleModel> allVehicle)
        {
            this.RaceID = raceID;
            this.RaceStatus = raceStatus;
            this.Distance = distance;
            this.Year = year;
            this.NumberByVehicleStatus = numberByVehicleStatus;
            this.NumberByVehicleType = numberByVehicleType;
            this.AllVehicle = allVehicle;
        }

        public int RaceID { get => raceID; set => raceID = value; }
        public string RaceStatus { get => raceStatus; set => raceStatus = value; }
        public int Distance { get => distance; set => distance = value; }
        public int Year { get => year; set => year = value; }
        public int NumberByVehicleStatus { get => numberByVehicleStatus; set => numberByVehicleStatus = value; }
        public int NumberByVehicleType { get => numberByVehicleType; set => numberByVehicleType = value; }
        public List<VehicleModel> AllVehicle { get => allVehicle; set => allVehicle = value; }
    }
}
