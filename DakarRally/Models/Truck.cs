using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRally.Models
{
    public class Truck : Vehicle
    {
        public Truck(int id, string name, string model, DateTime date) : base(speed: 80, lightMalfun: 6, heavyMulfun: 4)
        {
            this.Id = id;
            this.TeamName = name;
            this.Model = model;
            this.ManufacturingDate = date;
        }
    }
}