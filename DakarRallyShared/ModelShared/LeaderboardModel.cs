using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyShared.ModelShared
{
    public class LeaderboardModel
    {
        private string vehicleName;
        private string vehicleType;
        private int distance;
        private string time;
        private int status;

        public LeaderboardModel()
        {
        }

        public LeaderboardModel(string vehicleName, string vehicleType, int distance, string time, int status)
        {
            this.VehicleName = vehicleName;
            this.VehicleType = vehicleType;
            this.Distance = distance;
            this.Time = time;
        }

        public string VehicleName { get => vehicleName; set => vehicleName = value; }
        public string VehicleType { get => vehicleType; set => vehicleType = value; }
        public int Distance { get => distance; set => distance = value; }
        public string Time { get => time; set => time = value; }
        public int Status { get => status; set => status = value; }
    }
}
