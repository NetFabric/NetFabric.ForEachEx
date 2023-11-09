using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using NetFabric;

public class ForEachExEnumerableBenchmarks
{
    int[]? array;

    [Params(10_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var enumerable = Utils.GetEnumerable(Count, 100);
        array = enumerable.ToArray();
    }

    [Benchmark(Baseline = true)]
    public int Array()
    {
        var sum = new SumValueAction<int>();
        array!.ForEachEx(ref sum);
        return sum.Result;
    }

    [Benchmark]
    public int Array_AsEnumerable()
    {
        var sum = new SumValueAction<int>();
        ((IEnumerable<int>)array!).ForEachEx(ref sum);
        return sum.Result;
    }
}


