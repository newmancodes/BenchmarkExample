using BenchmarkDotNet.Running;

namespace Api.BenchmarkTests
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<WeatherForecastBenchmarks>();
        }
    }
}
