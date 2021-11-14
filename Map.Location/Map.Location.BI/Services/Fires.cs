using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.BI.Interfaces;
using Map.Location.Data.Base;
using Map.Location.BI.Options;
using Map.Location.Data.Dto;
using Map.Location.General.Expansions;

namespace Map.Location.BI.Services
{
    public class Fires : IFires
    {
        private readonly IWeather _weather;
        private readonly MapConfig _config;
        public static List<Fire> FiresList = new List<Fire>();

        public Fires(IWeather weather, MapConfig config)
        {
            _weather = weather;
            _config = config;
        }
        
        public async Task AddFire(Fire fire)
        {
            fire.Weather = await _weather.Get(fire.Coordinates);

            fire.Witnesses.AddRange(AddWitnesses(fire));

            FiresList.Add(fire);
        }

        public List<Fire> GetFires() => FiresList;

        private IList<Sensor> AddWitnesses(Fire fire)
        {
            return FiresList.SelectMany(x => x.Witnesses).GroupBy(x => x.Id)
             .Select(a => a.First()).Where(x => CalculateDistance(x.Coordinates, fire.Coordinates) <= 10000).ToList();
        }

        private double CalculateDistance(Coordinates point1, Coordinates point2)
        {
            var d1 = point1.Lat * (Math.PI / 180.0);
            var num1 = point1.Lon * (Math.PI / 180.0);
            var d2 = point2.Lat * (Math.PI / 180.0);
            var num2 = point2.Lon * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
