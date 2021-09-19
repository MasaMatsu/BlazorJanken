using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Domain.Models;

namespace BlazorJanken.Services
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient httpClient)
        {
            _client = httpClient;

            // Switch here to production API URI.
            // TODO: Use appsettings.json
            _client.BaseAddress = new Uri("https://localhost:30373");
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            try
            {
                return await _client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
            }
            catch 
            {
                return Enumerable.Empty<WeatherForecast>();
            }
        }
    }
}
