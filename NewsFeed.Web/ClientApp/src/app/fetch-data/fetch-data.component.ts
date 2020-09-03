import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public weatherForecast: WeatherForecastModel;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http
      .get<WeatherForecast[]>(baseUrl + 'weatherforecast')
      .subscribe(result => {
        this.forecasts = result;
      }, error => console.error(error));

      http
      .get<WeatherForecastModel>(baseUrl + 'api/v1/Weather/Australia/Nsw/Sydney')
      .subscribe(result => {
        this.weatherForecast = result;
      }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface WeatherForecastModel {
  Id: string;
  LocationInState: string;
  LocationState: string;
  RefreshMessage: string
  TimeZone: string
  DayForecasts: DayForecastModel[];
}

interface DayForecastModel {
  Location: string
  LocalTime: string;
  AirTemperature: number;
  WindDirection: string;
  WindSpeedKmHr: number;
}