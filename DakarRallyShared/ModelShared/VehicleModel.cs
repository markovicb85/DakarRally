using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyShared.ModelShared
{
    /// <summary>
    /// Represent one specificvehicle
    /// </summary>
    public class VehicleModel
    {
        /// <summary>
        /// Id for vehicle
        /// </summary>
        private int vehicleId;
        
        /// <summary>
        /// Team name for vehicle
        /// </summary>
        private string teamName;

        /// <summary>
        /// Vehicle model(sport motorcycle, cross motorcycle...)
        /// </summary>
        private string model;

        /// <summary>
        /// Vehicle type(car, motorcycle or truck)
        /// </summary>
        private int type;

        /// <summary>
        /// Manufacturing date
        /// </summary>
        private string manufacturingDate;

        /// <summary>
        /// Max speed
        /// </summary>
        private int speed;

        /// <summary>
        /// Probabilities of light malfunctions
        /// </summary>
        private int lightMalfun;

        /// <summary>
        /// Probabilities of heavy malfunctions
        /// </summary>
        private int heavyMalfun;

        /// <summary>
        /// Repairments time
        /// </summary>
        private int malfunctionTime;

        /// <summary>
        /// Id for race
        /// </summary>
        private int raceId;

        /// <summary>
        /// Distance calculated by simulation
        /// </summary>
        private int distance;

        /// <summary>
        /// Vehicle status during simulation (heavy malfunction, light malfunction...) 
        /// </summary>
        private int vehicleStatus = 0;

        /// <summary>
        /// Race time calculated by simulation
        /// </summary>
        private string time;

        public VehicleModel()
        {
        }

        public int VehicleId { get => vehicleId; set => vehicleId = value; }
        public string TeamName { get => teamName; set => teamName = value; }
        public string Model { get => model; set => model = value; }
        public int Type { get => type; set => type = value; }
        public string ManufacturingDate { get => manufacturingDate; set => manufacturingDate = value; }
        public int Speed { get => speed; set => speed = value; }
        public int LightMalFun { get => lightMalfun; set => lightMalfun = value; }
        public int HeavyMalFun { get => heavyMalfun; set => heavyMalfun = value; }
        public int MalfunctionTime { get => malfunctionTime; set => malfunctionTime = value; }
        public int RaceId { get => raceId; set => raceId = value; }
        public int Distance { get => distance; set => distance = value; }
        public int VehicleStatus { get => vehicleStatus; set => vehicleStatus = value; }
        public string Time { get => time; set => time = value; }
    }
}
