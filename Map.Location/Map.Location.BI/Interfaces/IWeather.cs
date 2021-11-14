using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.Data.Base;
using Map.Location.Data.Dto;

namespace Map.Location.BI.Interfaces
{
    public interface IWeather
    {
        Task<WeatherCurrent> Get(Coordinates coordinates);
    }
}
