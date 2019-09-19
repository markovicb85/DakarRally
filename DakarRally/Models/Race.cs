using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRally.Models
{
    public class Race
    {
        private int raceID;
        private string raceStatus;
        private int distance = 10000;
        private int year;
        private int numberByVehicleStatus;
        private int numberByVehicleType;
        private List<Vehicle> allVehicle;

        public Race()
        {
        }

        public Race(int raceID, string raceStatus, int distance, int year, List<Vehicle> allVehicle)
        {
            this.RaceID = raceID;
            this.RaceStatus = raceStatus;
            this.Distance = distance;
            this.Year = year;
            this.AllVehicle = allVehicle;
        }

        public int RaceID { get => raceID; set => raceID = value; }
        public string RaceStatus { get => raceStatus; set => raceStatus = value; }
        public int Distance { get => distance; set => distance = value; }
        public int Year { get => year; set => year = value; }
        public int NumberByVehicleStatus { get => numberByVehicleStatus; set => numberByVehicleStatus = value; }
        public int NumberByVehicleType { get => numberByVehicleType; set => numberByVehicleType = value; }
        public List<Vehicle> AllVehicle { get => allVehicle; set => allVehicle = value; }
    }
}