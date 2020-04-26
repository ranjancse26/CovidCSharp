using System;
using System.Collections.Generic;
using CovidCSharp.NET;
using CovidCSharp.NET.Entities.Case;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCases("india");

            CountryService countryService = new CountryService();
            var countries = countryService.GetCountries();

            StatisticsService statisticsService = new StatisticsService();
            var stats = statisticsService.GetStatistics();

            SummaryService summaryService = new SummaryService();
            var summary = summaryService.GetGlobalSummary();

            System.Console.ReadLine();
        }

        private static void GetCases(string country)
        {
            // Note - Case status can be - confirmed, recovered, deaths
            
            CaseService caseService = new CaseService();
            IEnumerable<CoronaCase> cases = caseService.GetDayOneCasesByCountry(country);

            // day one cases by country with status
            cases = caseService.GetDayOneCasesByCountry(country, "deaths");

            // day one total confirmed cases by country
            cases = caseService.GetDayOneTotalConfirmedCasesByCountry(country);

            // day one live cases by country
            cases = caseService.GetDayOneLiveCasesByCountry(country);

            // day one total all status cases by country
            cases = caseService.GetDayOneTotalAllStatusCasesByCountry(country);

            // Day one live cases by country
            cases = caseService.GetDayOneLiveCasesByCountry(country);

            // Day one total cases all status
            cases = caseService.GetDayOneTotalAllStatusCasesByCountry(country);

            // total confirmed cases by country
            cases = caseService.GetDayOneTotalConfirmedCasesByCountry(country);

            // live confirmed cases by country
            cases = caseService.GetLiveConfirmedCasesByCountry(country,
                DateTime.Parse("2020-04-20"),
                DateTime.Parse("2020-04-21"));

            // total cases all status by country
            cases = caseService.GetTotalCasesAllStatusByCountry(country);

            // total live cases after date
            cases = caseService.GetLiveByCountryAndStatusAfterDate(country,
                DateTime.Parse("2020-04-20"));

            // live by country 
            cases = caseService.GetLiveByCountryAndAllStatus(country);

            // world total wip cases
            var worldWIPCases = caseService.GetWorldTotalWIPCases();
        }
    }
}
