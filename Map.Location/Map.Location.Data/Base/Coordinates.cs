using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Location.Data.Base
{
    public class Coordinates
    {
        //Широта 
        public double Lat { get; set; }

        //Долгота
        public double Lon { get; set; }

        public override string ToString()
        {
            return $"{Lat}, {Lon}";
        }

        public string ToMaxString()
        {
            return $"Широта {Lat}, Долгота {Lon}.";
        }
    }
}
