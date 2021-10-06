using BenchmarkDotNet.Running;


namespace DotNetBenchmarks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<EnumNameConversionBenchmark>();
        }
    }
}
