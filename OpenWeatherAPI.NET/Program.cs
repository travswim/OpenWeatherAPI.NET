using OpenWeather;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace OpenWeather.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string CODE = "16203ed9d9f4e7286a07ff4aef754f77";
            string CityName = "Vancouver";
            int CityCode = 6173331;
            string CountryCode = "CA";

            double lon = -123.119339;
            double lat = 49.24966;
            
            string jsonString = GetJSON(string.Format(CurrentWeather.LOC_NAME, CityName.Replace(" ", "%20"), CountryCode, CODE));
            CurrentWeather currentWeather = JsonSerializer.Deserialize<CurrentWeather>(jsonString);

            Console.WriteLine(currentWeather.Weather[0]["id"]);
           

            //Weather weather = new Weather(CODE, CityName, CountryCode);
            //Console.WriteLine(weather.DateTimeNow());

        }

        /// <summary>
        /// Retrieves a JSON string from a web API given a valid URL
        /// </summary>
        /// <param name="address">http or https URL</param>
        /// <returns>A JSON string</returns>
        public static string GetJSON(string address)
        {
            // Initiate a webclient and get the string returned
            WebClient client = new WebClient();
            string reply = client.DownloadString(address);

            //Console.WriteLine(reply);
            return reply;

        }
    }
}
