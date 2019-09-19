using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRally.Models
{
    public class TerrainCar : Vehicle
    {
        public TerrainCar(int id, string name, string model, DateTime date) : base(speed: 100, lightMalfun: 3, heavyMulfun: 1)
        {
            this.Id = id;
            this.TeamName = name;
            this.Model = model;
            this.ManufacturingDate = date;
        }
    }
}