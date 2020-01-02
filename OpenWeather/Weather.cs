using OpenWeather;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace OpenWeather
{
    // TODO: Create and Test all constructors
    public class Weather
    {
        public CurrentWeather CurrentWeatherNow { get; set; }

        /// <summary>
        /// Constructor using city name and country code
        /// </summary>
        /// <param name="code">URL access code</param>
        /// <param name="city">City name</param>
        /// <param name="countrycode">country code</param>
        public Weather(string code, string city, string countryCode)
        {
            string jsonString = GetJSON(string.Format(CurrentWeather.LOC_NAME, city.Replace(" ", "%20"), countryCode, code));
            this.CurrentWeatherNow = JsonSerializer.Deserialize<CurrentWeather>(jsonString);
        }

        /// <summary>
        /// Constructor using city code
        /// </summary>
        /// <param name="code">URL access code</param>
        /// <param name="citycode">City code from .json file</param>
        public Weather(int code, int citycode)
        {
            string jsonString = GetJSON(string.Format(CurrentWeather.LOC_CODE, code, citycode.ToString()));
            this.CurrentWeatherNow = JsonSerializer.Deserialize<CurrentWeather>(jsonString);
        }

        /// <summary>
        /// Constructor using city code
        /// </summary>
        /// <param name="code">URL access code</param>
        /// <param name="citycode">City code from .json file</param>
        public Weather(int code, double latitude, double longitude)
        {
            string jsonString = GetJSON(string.Format(CurrentWeather.LOC_GPS, code, latitude.ToString(), longitude.ToString()));
            this.CurrentWeatherNow = JsonSerializer.Deserialize<CurrentWeather>(jsonString);
        }

        public DateTime DateTimeNow()
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(this.CurrentWeatherNow.DT).ToLocalTime();
            return dtDateTime;
        }

        public int DateTimeNow_RAW()
        {
            return this.CurrentWeatherNow.DT;
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
