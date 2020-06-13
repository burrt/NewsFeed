# News feed application

![Build Status](https://github.com/burrt/NewsFeed/workflows/CI/badge.svg?branch=master)
[![Build Status](https://geoffchoy.visualstudio.com/NewsFeed/_apis/build/status/burrt.NewsFeed?branchName=master)](https://geoffchoy.visualstudio.com/NewsFeed/_build/latest?definitionId=1&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=burrt_NewsFeed&metric=alert_status)](https://sonarcloud.io/dashboard?id=burrt_NewsFeed)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=burrt_NewsFeed&metric=coverage)](https://sonarcloud.io/dashboard?id=burrt_NewsFeed)

A basic application for retrieving news information from the internet and experimenting with various technologies, tools, design patterns and a bit of fun!

## Getting started

This project was built using Visual Studio 2019 targeting .NET Core 3.1.100 LTS.

```bash
# clone the repository
$ git clone https://github.com/burrt/NewsFeed.git

# build the solution
$ msbuild -t:restore
$ msbuild NewsFeed.sln

# run the tests
$ dotnet test
```

## Remarks

For some interesting unit testing, see:

* `BomHttpClientTests` - testing `HttpClient`
* `ConsolePrinterTests` - testing writing output to console
