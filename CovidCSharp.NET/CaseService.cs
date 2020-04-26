using System;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using CovidCSharp.NET.Utility;
using CovidCSharp.NET.Entities.Case;
using CovidCSharp.NET.Entities.World;

namespace CovidCSharp.NET
{
    public interface ICaseService
    {
        IEnumerable<CoronaCase> GetDayOneCasesByCountry(string country,
            string caseStatus);
        IEnumerable<CoronaCase> GetDayOneCasesByCountry(string country);
        IEnumerable<CoronaCase> GetDayOneLiveCasesByCountry(string country);
        IEnumerable<CoronaCase> GetDayOneTotalConfirmedCasesByCountry(string country);
        IEnumerable<CoronaCase> GetDayOneTotalAllStatusCasesByCountry(string country);
        IEnumerable<CoronaCase> GetConfirmedCasesByCountry(string country,
                DateTime fromDate, DateTime toDate);
        IEnumerable<CoronaCase> GetCasesByCountryAllStatus(string country,
           DateTime fromDate, DateTime toDate);
        IEnumerable<CoronaCase> GetLiveConfirmedCasesByCountry(string country,
           DateTime fromDate, DateTime toDate);
        IEnumerable<CoronaCase> GetConfirmedTotalCasesByCountry(string country,
           DateTime fromDate, DateTime toDate);
        IEnumerable<CoronaCase> GetTotalCasesAllStatusByCountry(string country);
        IEnumerable<CoronaCase> GetConfirmedLiveByCountryAndStatus(string country);
        IEnumerable<CoronaCase> GetLiveByCountryAndAllStatus(string country);
        IEnumerable<CoronaCase> GetLiveByCountryAndStatusAfterDate(string country,
                DateTime afterDate);
        WorldTotal GetWorldWIPCases(DateTime fromDate,
            DateTime toDate);
        WorldTotal GetWorldTotalWIPCases();
        IEnumerable<CoronaCase> GetAllCases();
    }

    public class BaseCaseService
    {
        public IEnumerable<CoronaCase> InitCaseRequest(HttpWebRequest httpWebRequest)
        {
            string response = httpWebRequest.GetResponseString();
            if (!string.IsNullOrEmpty(response))
                return JsonSerializer.Deserialize<IEnumerable<CoronaCase>>(response);
            return null;
        }
    }

    public class CaseService : BaseCaseService, ICaseService
    {
        private string baseUrl = "https://api.covid19api.com";

        public IEnumerable<CoronaCase> GetDayOneCasesByCountry(string country,
            string caseStatus)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/dayone/country/{country}/status/{caseStatus}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetDayOneCasesByCountry(string country)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/dayone/country/{country}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetDayOneLiveCasesByCountry(string country)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/dayone/country/{country}/status/confirmed/live");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetDayOneTotalConfirmedCasesByCountry(string country)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/total/dayone/country/{country}/status/confirmed");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetDayOneTotalAllStatusCasesByCountry(string country)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/total/dayone/country/{country}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetConfirmedCasesByCountry(string country,
            DateTime fromDate, DateTime toDate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/country/{country}/status/confirmed?from={fromDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}&to={toDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetCasesByCountryAllStatus(string country,
           DateTime fromDate, DateTime toDate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/{country}?from={fromDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}&to={toDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetLiveConfirmedCasesByCountry(string country,
           DateTime fromDate, DateTime toDate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/country/{country}/status/confirmed/live?from={fromDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}&to={toDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetConfirmedTotalCasesByCountry(string country,
           DateTime fromDate, DateTime toDate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/total/country/{country}/status/confirmed?from={fromDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}&to={toDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetTotalCasesAllStatusByCountry(string country)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/total/country/{country}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetConfirmedLiveByCountryAndStatus(string country)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/live/country/{country}/status/confirmed");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetLiveByCountryAndAllStatus(string country)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/live/country/{country}");
            return InitCaseRequest(request);
        }

        public IEnumerable<CoronaCase> GetLiveByCountryAndStatusAfterDate(string country,
            DateTime afterDate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/live/country/{country}/status/confirmed/date/{afterDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            return InitCaseRequest(request);
        }

        public WorldTotal GetWorldWIPCases(DateTime fromDate,
            DateTime toDate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/world?from={fromDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}&to={toDate.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            string response = request.GetResponseString();
            if (!string.IsNullOrEmpty(response))
                return JsonSerializer.Deserialize<WorldTotal>(response);
            return null;
        }

        public WorldTotal GetWorldTotalWIPCases()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/world/total");
            string response = request.GetResponseString();
            if (!string.IsNullOrEmpty(response))
                return JsonSerializer.Deserialize<WorldTotal>(response);
            return null;
        }

        public IEnumerable<CoronaCase> GetAllCases()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}/all");
            return InitCaseRequest(request);
        }
    }
}
