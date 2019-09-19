using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyShared.ModelShared
{
    public class VehicleModel
    {
        private int vehicleId;
        private string teamName;
        private string model;
        private string manufacturingDate;
        private int speed;
        private int lightMalfun;
        private int heavyMalfun;
        private int raceId;

        private int distance;
        private int malfuctionStatus;
        private int raceStatus;
        private int time;

        public VehicleModel()
        {
        }

        public VehicleModel(int id, string teamName, string model, string manufacturingDate, int speed, int lightMalfun, 
                                int heavyMulfun, int raceId, int distance, int malfuctionStatus, int raceStatus, int time)
        {
            this.VehicleId = vehicleId;
            this.TeamName = teamName;
            this.Model = model;
            this.ManufacturingDate = manufacturingDate;
            this.Speed = speed;
            this.LightMalFun = lightMalfun;
            this.HeavyMalFun = heavyMulfun;
            this.RaceId = raceId;
            this.Distance = distance;
            this.MalfuctionStatus = malfuctionStatus;
            this.RaceStatus = raceStatus;
            this.Time = time;
        }

        public int VehicleId { get => vehicleId; set => vehicleId = value; }
        public string TeamName { get => teamName; set => teamName = value; }
        public string Model { get => model; set => model = value; }
        public string ManufacturingDate { get => manufacturingDate; set => manufacturingDate = value; }
        public int Speed { get => speed; set => speed = value; }
        public int LightMalFun { get => lightMalfun; set => lightMalfun = value; }
        public int HeavyMalFun { get => heavyMalfun; set => heavyMalfun = value; }
        public int RaceId { get => raceId; set => raceId = value; }
        public int Distance { get => distance; set => distance = value; }
        public int MalfuctionStatus { get => malfuctionStatus; set => malfuctionStatus = value; }
        public int RaceStatus { get => raceStatus; set => raceStatus = value; }
        public int Time { get => time; set => time = value; }
    }
}
