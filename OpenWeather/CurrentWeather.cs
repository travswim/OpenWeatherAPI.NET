using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
// TODO: Retrieve weather as is
// TODO: Retrieve weather in different units
// TODO: Retrieve weather in type or string format
// TODO: Retrieve data from gps, name, or IP address
namespace OpenWeather
{
    public class CurrentWeather
    {
        public static string WEA = "https://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid={2}";
        //[JsonPropertyName("weather")]
        //public IList<Dictionary<string, string>> Weather { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        [JsonPropertyName("main")]
        public Dictionary<string, double> Main { get; set; }
        [JsonPropertyName("wind")]
        public Dictionary<string, double> Wind { get; set; }
        [JsonPropertyName("clouds")]
        public Dictionary<string, int> Clouds { get; set; }

        
        [JsonPropertyName("dt")]
        public int DT { get; set; }
            
        [JsonPropertyName("sys")]
        public WeatherSystem Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int TimeZone { get; set; }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string CityName { get; set; }
        [JsonPropertyName("cod")]
        public int Code { get; set; }

        public class WeatherSystem
        {
            public int type { get; set; }
            public int id { get; set; }
            public float message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }



    }
}
