using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        WeatherModel weatherModel = new WeatherModel();
        private string CityName { get; set; }
        [HttpGet("city")]
        public ActionResult WeatherDisplay(string city)
        {
            
            var TemperatureInFareheit= 0; 
            double TemperatureInCelcius = 0;
            string result = "";
            WebClient webClient = new WebClient();
            result = webClient.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text=%27"+city+",%20IN%27)&format=json");
            dynamic jobject = JObject.Parse(result);
            var items = jobject.query.results.channel;
            weatherModel.Location = items.location.city;
            weatherModel.DateAndTimeOfMeasuring = items.item.condition.date;
            TemperatureInFareheit = items.item.condition.temp;
            weatherModel.WeatherCondition = items.item.condition.text;
            weatherModel.Humidity = items.atmosphere.humidity;
            TemperatureInCelcius = 5.0 / 9.0 * (TemperatureInFareheit - 32);
            weatherModel.Temperature = TemperatureInCelcius.ToString() + "°C";

            return View(weatherModel);
        }
       
        public ActionResult EnterCityName()
        {
            return View();
        }
    }
}