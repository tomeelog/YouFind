
PROJECT 1
==========
Reporting Service

## Environment
Framework: .Net Core 3.1

### Projects 
YouFindAssessment.Task2: .Net Core Console Application
* Task2.Test: .Net NUnit Test Project

## Build & Run
```
dotnet build && dotnet test

dotnet run -p YouFindAssessment.Task2/YouFindAssessment.Task2.csproj
```
## Output
Output file: HotelRateReport_ddMMyy-HHss.xlsx

PROJECT 2
========
Web Service / API

## Environment
Framework: .Net core 3.1


### Projects 
* YouFindAssessment.Task3: .Net WebApi Project
* Task3.Test: .Net NUnit Test Project

## Build & Run

```
dotnet build && dotnet test

dotnet run -p YouFindAssessment.Task3/YouFindAssessment.Task3.csproj
```
## Request

Request to obtain hotel rates by HotelID and ArrivalDate:

```
GET /HotelRates/GetHotelRates/7294?arrivalDate=2016-03-18 HTTP/1.1
Host: localhost:5001