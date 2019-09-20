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
        /// <summary>
        /// Race Id
        /// </summary>
        private int raceID;

        /// <summary>
        /// Status during the race (pending, running, finished)
        /// </summary>
        private int raceStatus;

        /// <summary>
        /// Race length
        /// </summary>
        private int distance = 10000;

        /// <summary>
        /// Race start year
        /// </summary>
        private int year;     
        
        public RaceModel()
        {
        }

        public int RaceID { get => raceID; set => raceID = value; }
        public int RaceStatus { get => raceStatus; set => raceStatus = value; }
        public int Distance { get => distance; set => distance = value; }
        public int Year { get => year; set => year = value; }
        
    }
}