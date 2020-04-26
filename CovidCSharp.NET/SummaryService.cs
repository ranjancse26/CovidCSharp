using System.Net;
using System.Text.Json;
using CovidCSharp.NET.Utility;
using CovidCSharp.NET.Entities.Global;

namespace CovidCSharp.NET
{
    public interface ISummaryService
    {
        GlobalSummary GetGlobalSummary();
    }

    public class SummaryService : ISummaryService
    {
        private string baseUrl = "https://api.covid19api.com";
        public GlobalSummary GetGlobalSummary()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/summary");
            string response = request.GetResponseString();
            if (!string.IsNullOrEmpty(response))
                return JsonSerializer.Deserialize<GlobalSummary>(response);
            return null;
        }
    }
}
