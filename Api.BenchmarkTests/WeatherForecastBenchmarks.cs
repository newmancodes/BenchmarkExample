using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Api.BenchmarkTests
{
    [MemoryDiagnoser]
    public class WeatherForecastBenchmarks : IDisposable
    {
        private readonly WebApplicationFactory<Startup> factory;
        private readonly HttpClient client;

        public WeatherForecastBenchmarks()
        {
            this.factory = new WebApplicationFactory<Startup>();
            this.client = factory.CreateClient();
        }

        [Benchmark]
        public async Task GetWeatherForecast()
        {
            using var cancellationTokenSource = new CancellationTokenSource();
            await this.client.GetAsync("/weatherforecast", cancellationTokenSource.Token);
        }

        public void Dispose()
        {
            client?.Dispose();
            factory?.Dispose();
        }
    }
}
