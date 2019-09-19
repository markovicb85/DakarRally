using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRally.Models
{
    public class SportsCar : Vehicle
    {
        public SportsCar(int id, string name, string model, DateTime date) : base(speed: 140, lightMalfun: 12, heavyMulfun: 2)
        {
            this.Id = id;
            this.TeamName = name;
            this.Model = model;
            this.ManufacturingDate = date;            
        }
    }
}