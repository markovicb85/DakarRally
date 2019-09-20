using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyShared.ModelShared
{
    public class RaceStatisticModel
    {
        private int raceStatus;
        private int motorcycleNum = 0;
        private int carNum = 0;
        private int truckNum = 0;
        private int statusPendingNum = 0;
        private int statusRunningNum = 0;
        private int statusFinishedNum = 0;

        public RaceStatisticModel()
        {
        }

        public int RaceStatus { get => raceStatus; set => raceStatus = value; }
        public int CarNum { get => carNum; set => carNum = value; }
        public int MotorcycleNum { get => motorcycleNum; set => motorcycleNum = value; }
        public int TruckNum { get => truckNum; set => truckNum = value; }
        public int StatusPendingNum { get => statusPendingNum; set => statusPendingNum = value; }
        public int StatusRunningNum { get => statusRunningNum; set => statusRunningNum = value; }
        public int StatusFinishedNum { get => statusFinishedNum; set => statusFinishedNum = value; }
    }
}
