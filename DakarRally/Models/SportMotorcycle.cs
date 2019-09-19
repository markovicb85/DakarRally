using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DakarRally.Models
{
    public class SportMotorcycle : Vehicle
    {
        public SportMotorcycle(int id, string name, string model, DateTime date) : base(speed: 130, lightMalfun: 18, heavyMulfun: 10)
        {
            this.Id = id;
            this.TeamName = name;
            this.Model = model;
            this.ManufacturingDate = date;
        }
    }
}