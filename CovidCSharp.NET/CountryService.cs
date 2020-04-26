using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using CovidCSharp.NET.Utility;
using CovidCSharp.NET.Entities.Country;
using CovidCSharp.NET.Entities.Case;

namespace CovidCSharp.NET
{
    public interface ICountryService
    {
        IEnumerable<AllCountry> GetCountries();
    }

    public class CountryService : ICountryService
    {
        private string baseUrl = "https://api.covid19api.com";
        public IEnumerable<AllCountry> GetCountries()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/countries");
            string response = request.GetResponseString();
            if (!string.IsNullOrEmpty(response))
                return JsonSerializer.Deserialize<IEnumerable<AllCountry>>(response);
            return null;
        }
    }
}
