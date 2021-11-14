using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Location.Data.Base;

namespace Map.Location.Data.Dto
{
    public class WeatherCurrent
    {
        public Coordinates Coord { get; set; }

        public IList<WeatherModel> Weather { get; set; }

        public Wind Wind { get; set; }

        public MainWeather Main { get; set; }

        public override string ToString()
        {
            return $"Координаты объекта: {Coord.ToString()}\n{Main.ToString()}, {Weather.First().Description}.\n{Wind.ToString()}";
        }

    }

    public class WeatherModel
    {
        public string Main { get; set; }

        public string Description { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }

        public double Gust { get; set; }

        public double Deg { get; set; }

        public override string ToString()
        {
            return $"Ветер {GustToString()} скоростью ~{Speed}м/с, с порывами до {Gust}м/с";
        }

        private string GustToString()
        {
            if (Deg >= 360 - 22 || Deg <= 22)
                return "северный";
            if (Deg >= 292)
                return "северо-западный";
            if (Deg >= 248)
                return "западный";
            if (Deg >= 202)
                return "юго-западный";
            if (Deg >= 158)
                return "южный";
            if (Deg >= 112)
                return "юго-восточный";
            if (Deg >= 68)
                return "восточный";

            return "северо-восточный";
        }
    }

    public class MainWeather
    {
        public double Temp { get; set; }

        public double Humidity { get; set; }

        public override string ToString()
        {
            return $"Температура воздуха {Temp}, с влажностью {Humidity}%";
        }
    }
}
