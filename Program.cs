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
            Console.WriteLine("Hello World!");
            //CustomClass.GetDataWithForeach();

            var config = DefaultConfig.Instance.WithSummaryStyle(SummaryStyle.Default.WithTimeUnit(TimeUnit.Millisecond));
            var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<CustomClass>(config, args);          
        }

        [MemoryDiagnoser]
        [MeanColumn]
        [Config(typeof(SerialiserBenchmarksConfig))]
        public class CustomClass
        {
            //string[] arr = { "Jack", "Jessi", "Erica", "John" };

            static int[] arr = new int[5];
            
            public static void PopulateData()
            {
                int Min = 0;
                int Max = 20;

                //int[] arr = new int[5];

                Random randNum = new Random();

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = randNum.Next(Min, Max);
                    //Console.WriteLine(arr[i]);
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
