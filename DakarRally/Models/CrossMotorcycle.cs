using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRally.Models
{
    public class CrossMotorcycle : Vehicle
    {
        public CrossMotorcycle(int id, string name, string model, DateTime date) : base(speed: 85, lightMalfun: 3, heavyMulfun: 2)
        {
            this.Id = id;
            this.TeamName = name;
            this.Model = model;
            this.ManufacturingDate = date;
        }
    }
}