using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRally.Models
{
    public class Vehicle
    {
        private int id;
        private string teamName;
        private string model;
        private DateTime manufacturingDate;
        private int speed;
        private int lightMalfun;
        private int heavyMulfun;

        private int distance;
        private int malfuctionStatus;
        private int raceStatus;
        private int time;

        public Vehicle()
        {
        }

        public Vehicle(int speed, int lightMalfun, int heavyMulfun)
        {
            this.Speed = speed;
            this.LightMalfun = lightMalfun;
            this.HeavyMulfun = heavyMulfun;
        }

        public Vehicle(int id, string teamName, string model, DateTime manufacturingDate, int speed, int lightMalfun, int heavyMulfun, int distance, int malfuctionStatus, int raceStatus, int time)
        {
            this.Id = id;
            this.TeamName = teamName;
            this.Model = model;
            this.ManufacturingDate = manufacturingDate;
            this.Speed = speed;
            this.LightMalfun = lightMalfun;
            this.HeavyMulfun = heavyMulfun;
            this.distance = distance;
            this.malfuctionStatus = malfuctionStatus;
            this.raceStatus = raceStatus;
            this.time = time;
        }

        
        public int Id { get => id; set => id = value; }
        public string TeamName { get => teamName; set => teamName = value; }
        public string Model { get => model; set => model = value; }
        public DateTime ManufacturingDate { get => manufacturingDate; set => manufacturingDate = value; }
        public int Speed { get => speed; set => speed = value; }
        public int LightMalfun { get => lightMalfun; set => lightMalfun = value; }
        public int HeavyMulfun { get => heavyMulfun; set => heavyMulfun = value; }
        public int Distance { get => distance; set => distance = value; }
        public int MalfuctionStatus { get => malfuctionStatus; set => malfuctionStatus = value; }
        public int RaceStatus { get => raceStatus; set => raceStatus = value; }
        public int Time { get => time; set => time = value; }
    }
}