using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests.Controllers
{
    public class WeatherForecastControllerTests : IDisposable
    {
        private readonly WebApplicationFactory<Startup> factory = new();

        [Fact]
        public async Task A_Weather_Forecast_Can_Be_Retrieved()
        {
            // Arrange
            using var cancellationTokenSource = new CancellationTokenSource();
            using var client = this.factory.CreateClient();

            // Act
            var response = await client.GetAsync("/weatherforecast", cancellationTokenSource.Token);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public void Dispose()
        {
            factory?.Dispose();
        }
    }
}
