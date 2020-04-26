using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using CovidCSharp.NET.Utility;
using CovidCSharp.NET.Entities.Statistics;

namespace CovidCSharp.NET
{
    public interface IStatisticsService
    {
        Statistics GetStatistics();
    }

    public class StatisticsService : IStatisticsService
    {
        private string baseUrl = "https://api.covid19api.com";
        public Statistics GetStatistics()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/stats");
            string response = request.GetResponseString();
            if (!string.IsNullOrEmpty(response))
                return JsonSerializer.Deserialize<Statistics>(response);
            return null;
        }
    }
}
