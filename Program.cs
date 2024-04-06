using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using Perfolizer.Horology;
using System;
using System.Collections.Generic;

namespace OurBenchmarkApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = DefaultConfig.Instance.WithSummaryStyle(SummaryStyle.Default.WithTimeUnit(TimeUnit.Millisecond));
            var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<CustomClass>(config, args);        
        }

        [MemoryDiagnoser]
        [Config(typeof(SerialiserBenchmarksConfig))]
        public class CustomClass
        {
            static int[] arr = new int[1000];
            
            public static void PopulateData()
            {
                int Min = 100;
                int Max = 1000;

                Random randNum = new Random();

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = randNum.Next(Min, Max);
                }
            }

            [Benchmark]
            public void GetDataWithWhile()
            {
                int i = 0;

                PopulateData();

                Console.WriteLine("With while Loop.");
                while (i < arr.Length)
                {
                    Console.WriteLine(arr[i]);
                    i++;
                }
            }

            [Benchmark]
            public void GetDataWithForeach()
            {
                PopulateData();

                Console.WriteLine("With foreach Loop.");
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
