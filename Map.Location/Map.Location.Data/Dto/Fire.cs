using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.Data.Base;


namespace Map.Location.Data.Dto
{
    public class Fire
    {
        public Coordinates Coordinates { get; set; }

        public WeatherCurrent Weather { get; set; }

        public List<Sensor> Witnesses { get; set; }
    }
}
