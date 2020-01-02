using OpenWeather;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace OpenWeatherAPI.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string CODE = "16203ed9d9f4e7286a07ff4aef754f77";
            string CityName = "West Vancouver";
            string CountryCode = "CA";
            //Console.WriteLine(string.Format(CurrentWeather.WEA, CityName.Replace(" ", "%20"), CountryCode, CODE));
            string jsonString = GetJSON(string.Format(CurrentWeather.WEA, CityName.Replace(" ", "%20"), CountryCode, CODE));
            CurrentWeather currentWeather = JsonSerializer.Deserialize<CurrentWeather>(jsonString);
            Console.WriteLine(currentWeather.Main["temp"]);
            Console.WriteLine(currentWeather.DT);
            Console.WriteLine(currentWeather.TimeZone);
            Console.WriteLine(currentWeather.Sys.sunrise);
            Console.WriteLine(currentWeather.Sys.sunset);

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
