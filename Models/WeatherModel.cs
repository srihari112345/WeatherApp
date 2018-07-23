using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public string Location { get; set; }
        public string DateAndTimeOfMeasuring { get; set; }
        public string Temperature { get; set; }
        public string WeatherCondition { get; set; }
        public string Humidity { get; set; }
        public string MyProperty { get; set; }

    }
}
