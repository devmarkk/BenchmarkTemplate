using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchy>();
        }
    }

    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchy
    {
        [Benchmark]
        public string GetConstString()
        {
            return string.Join('/', TestClass.CONST_STRING.Split(';'));
        }


        [Benchmark]
        public string GetStaticString()
        {
            return string.Join('/', TestClass.STATIC_STRING.Split(';'));
        }
    }

    public class TestClass
    {
        public const string CONST_STRING = "string;split;split";

        public static readonly string STATIC_STRING = "string;split;split";
    }
}
