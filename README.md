# CovidCSharp
A .NET Standard client for the COVID-19 API

## Installation
Installation is available in [NuGet](https://www.nuget.org/packages/CovidCSharp.NET)

## Usage

### Starting the client

```c#
// Note - Case status can be - confirmed, recovered, deaths
            
CaseService caseService = new CaseService();
IEnumerable<CoronaCase> cases = caseService.GetDayOneCasesByCountry("india");

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
```

### Get the list of countries

```c#
CountryService countryService = new CountryService();
var countries = countryService.GetCountries();
```

### Get COVID Stats

```c#
StatisticsService statisticsService = new StatisticsService();
var stats = statisticsService.GetStatistics();
```

### Get COVID Summary

```c#
SummaryService summaryService = new SummaryService();
var summary = summaryService.GetGlobalSummary();
```
