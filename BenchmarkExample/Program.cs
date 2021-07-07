using BenchmarkDotNet.Running;

namespace BenchmarkExample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<DateParserBenchmarks>();
        }
    }
}