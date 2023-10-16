using BenchmarkDotNet.Attributes;
using NetFabric;

public class ForEachVectorExBenchmarks
{
    int[]? array;

    [Params(10, 1_000)]
    public int Count { get; set; }

    static IEnumerable<int> GetEnumerable(int count)
    {
        var random = new Random(42);
        for (var item = 0; item < count; item++)
            yield return random.Next(count);
    }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var enumerable = GetEnumerable(Count);
        array = enumerable.ToArray();
    }

    [Benchmark(Baseline = true)]
    public int Array_foreach()
    {
        var sum = 0;
        foreach (var item in array!)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Array_Sum()
        => array!.Sum();

    [Benchmark]
    public int Array_ForEachEx_ValueAction()
    {
        var sum = new SumValueAction<int>();
        array!.ForEachEx(ref sum);
        return sum.Result;
    }

    [Benchmark]
    public int Array_ForEachEx_ValueVectorAction()
    {
        var sum = new SumValueAction<int>();
        array!.ForEachVectorEx(ref sum);
        return sum.Result;
    }
}


