using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyShared.ModelShared
{
    public class VehicleStatisticModel
    {
        private int distance;
        private int malfunction;
        private int status;
        private string time;

        public VehicleStatisticModel()
        {
        }

        public int Distance { get => distance; set => distance = value; }
        public int Malfunction { get => malfunction; set => malfunction = value; }
        public int Status { get => status; set => status = value; }
        public string Time { get => time; set => time = value; }
    }
}
