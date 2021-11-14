using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.BI.Interfaces;
using Map.Location.Data.Base;
using Map.Location.BI.Options;

namespace Map.Location.BI.Services
{
    public class Geolocations : IGeolocation
    {
        private readonly IDataSend _dataSend;
        private readonly MapConfig _config;

        public Geolocations(IDataSend dataSend, MapConfig config)
        {
            _dataSend = dataSend;
            _config = config;
        }

        public async Task<int> GetObjectsNearby(Coordinates coordinates)
        {
            return await _dataSend.Get<int>(_config.Url + $"?Lat={coordinates.Lat.ToString("G", CultureInfo.InvariantCulture)}&Lon={coordinates.Lon.ToString("G", CultureInfo.InvariantCulture)}");
        }
    }
}
