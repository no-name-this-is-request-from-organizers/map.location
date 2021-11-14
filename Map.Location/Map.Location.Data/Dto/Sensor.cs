using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.Data.Base;
using Map.Location.Data.Enums;

namespace Map.Location.Data.Dto
{
    public class Sensor
    {
        public int Id { get; set; }

        public PointType Type { get; set; }

        public Coordinates Coordinates { get; set; }
    }
}
