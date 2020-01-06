using OpenWeather;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace OpenWeather
{
    // TODO: Create and Test all constructors
    // TODO: Add language support
    // TODO: Add unit support (standard, metric, imperial)

    // To get language code
    //CultureInfo ci = CultureInfo.InstalledUICulture;
    //Console.WriteLine("* 2-letter ISO Name: {0}", ci.TwoLetterISOLanguageName);
    public class OpenWeather
    {
        public CurrentWeather CurrentWeatherNow { get; set; }

        /// <summary>
        /// Constructor using city name and country code
        /// </summary>
        /// <param name="code">URL access code</param>
        /// <param name="city">City name</param>
        /// <param name="countrycode">country code</param>
        public OpenWeather(string code, string city, string countryCode)
        {
            string jsonString = GetJSON(string.Format(CurrentWeather.LOC_NAME, city.Replace(" ", "%20"), countryCode, code));
            this.CurrentWeatherNow = JsonSerializer.Deserialize<CurrentWeather>(jsonString);
        }

        /// <summary>
        /// Constructor using city code
        /// </summary>
        /// <param name="code">URL access code</param>
        /// <param name="citycode">City code from .json file</param>
        public OpenWeather(int code, int citycode)
        {
            string jsonString = GetJSON(string.Format(CurrentWeather.LOC_CODE, code, citycode.ToString()));
            this.CurrentWeatherNow = JsonSerializer.Deserialize<CurrentWeather>(jsonString);
        }

        /// <summary>
        /// Constructor using city code
        /// </summary>
        /// <param name="code">URL access code</param>
        /// <param name="citycode">City code from .json file</param>
        public OpenWeather(int code, double latitude, double longitude)
        {
            string jsonString = GetJSON(string.Format(CurrentWeather.LOC_GPS, code, latitude.ToString(), longitude.ToString()));
            this.CurrentWeatherNow = JsonSerializer.Deserialize<CurrentWeather>(jsonString);
        }


        /// <summary>
        /// Weather condition id
        /// </summary>
        /// <returns>Weather condition ID</returns>
        public int ID()
        {
            return this.CurrentWeatherNow.Weathers[0].id;
        }
        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        /// <returns>The group of weather parameters</returns>
        public string Main()
        {
            return this.CurrentWeatherNow.Weathers[0].main;
        }

        /// <summary>
        /// Weather condition within the group
        /// </summary>
        /// <returns>The current weather conditions</returns>
        public string Description()
        {
            return this.CurrentWeatherNow.Weathers[0].description;
        }

        /// <summary>
        /// Weather icon id
        /// </summary>
        /// <returns>The current weather icon id</returns>
        public string Icon()
        {
            return this.CurrentWeatherNow.Weathers[0].icon;
        }

        /// <summary>
        /// Internal parameter
        /// </summary>
        /// <returns>Internal Parameter</returns>
        public string Base()
        {
            return this.CurrentWeatherNow.Base;
        }
        /// <summary>
        /// Returns the raw time in unix UTC format
        /// </summary>
        /// <returns>Seconds in unix UTC format</returns>
        public int DateTimeNow_RAW()
        {
            return this.CurrentWeatherNow.DT;
        }

        public double Temperature()
        {
            return this.CurrentWeatherNow.Main["temp"];
        }

        /// <summary>
        /// Calculates the time of weather parameters,
        /// and computes it to local time format YYYY-MM-DD HH:MM:SS AM/PM
        /// </summary>
        /// <returns>Time of data calculation formatted as a string
        public DateTime DateTimeNow()
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(this.CurrentWeatherNow.DT).ToLocalTime();
            return dtDateTime;
        }

        public int Sunset()
        {
            return this.CurrentWeatherNow.Sys.sunset;
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
