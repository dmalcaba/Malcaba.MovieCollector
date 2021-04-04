using System;
using System.Threading.Tasks;

namespace Malcaba.MovieCollector.Automation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Running movie extractor..");

            await MovieJsonExtractor.ExtractTestAsync();
        }
    }
}
