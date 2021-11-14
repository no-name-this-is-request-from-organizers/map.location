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

namespace Map.Location.BI.Services
{
    public class Weather : IWeather
    {
        private readonly IDataSend _dataSend;
        private readonly WeatherConfig _config;

        public Weather(IDataSend dataSend, WeatherConfig config)
        {
            _dataSend = dataSend;
            _config = config;
        }

        public async Task<WeatherCurrent> Get(Coordinates coordinates)
        {
            return await _dataSend.Get<WeatherCurrent>(_config.Url + $"?lat={coordinates.Lat.ToString("G", CultureInfo.InvariantCulture)}&lon={coordinates.Lon.ToString("G", CultureInfo.InvariantCulture)}&appid={_config.Token}&units=metric&lang=ru");
        }
    }
}
