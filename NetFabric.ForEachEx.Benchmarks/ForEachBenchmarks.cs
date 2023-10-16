using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using NetFabric;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class ForEachBenchmarks
{
    IEnumerable<int>? enumerable;
    List<int>? list;
    int[]? array;

    [Params(10, 1_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        enumerable = GetEnumerable(Count);
        list = enumerable.ToList();
        array = enumerable.ToArray();

        static IEnumerable<int> GetEnumerable(int count)
        {
            var random = new Random(42);
            for (var item = 0; item < count; item++)
                yield return random.Next(count);
        }
    }

    [BenchmarkCategory("Enumerable")]
    [Benchmark(Baseline = true)]
    public int Enumerable_foreach()
    {
        var sum = 0;
        foreach (var item in enumerable!)
            sum += item;
        return sum;
    }

    [BenchmarkCategory("Enumerable")]
    [Benchmark]
    public int Enumerable_Sum()
        => enumerable!.Sum();

    [BenchmarkCategory("Enumerable")]
    [Benchmark]
    public int Enumerable_MoreLinq()
    {
        var sum = 0;
        MoreLinq.MoreEnumerable.ForEach(enumerable!, item => sum += item);
        return sum;
    }

    [BenchmarkCategory("Enumerable")]
    [Benchmark]
    public int Enumerable_ForEachEx_Action()
    {
        var sum = 0;
        enumerable!.ForEachEx(item => sum += item);
        return sum;
    }

    [BenchmarkCategory("Enumerable")]
    [Benchmark]
    public int Enumerable_ForEachEx_ValueAction()
    {
        var sum = new SumValueAction<int>();
        enumerable!.ForEachEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("Enumerable")]
    [Benchmark]
    public int Enumerable_ForEachVectorEx()
    {
        var sum = new SumValueAction<int>();
        enumerable!.ForEachVectorEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("List")]
    [Benchmark(Baseline = true)]
    public int List_foreach()
    {
        var sum = 0;
        foreach (var item in list!)
            sum += item;
        return sum;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int List_foreach_AsSpan()
    {
        var sum = 0;
        foreach (var item in CollectionsMarshal.AsSpan(list!))
            sum += item;
        return sum;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int List_Sum()
        => list!.Sum();

    [BenchmarkCategory("List")]
    [Benchmark]
    public int List_ForEach()
    {
        var sum = 0;
        list!.ForEach(item => sum += item);
        return sum;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int List_MoreLinq()
    {
        var sum = 0;
        MoreLinq.MoreEnumerable.ForEach(list!, item => sum += item);
        return sum;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int List_ForEachEx_Action()
    {
        var sum = 0;
        list!.ForEachEx(item => sum += item);
        return sum;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int List_ForEachEx_ValueAction()
    {
        var sum = new SumValueAction<int>();
        list!.ForEachEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int List_ForEachVectorEx()
    {
        var sum = new SumValueAction<int>();
        list!.ForEachVectorEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int ListAsEnumerable_ForEachEx_Action()
    {
        var sum = 0;
        ((IEnumerable<int>)list!).ForEachEx(item => sum += item);
        return sum;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int ListAsEnumerable_ForEachEx_ValueAction()
    {
        var sum = new SumValueAction<int>();
        ((IEnumerable<int>)list!).ForEachEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("List")]
    [Benchmark]
    public int ListAsEnumerable_ForEachVectorEx()
    {
        var sum = new SumValueAction<int>();
        ((IEnumerable<int>)list!).ForEachVectorEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("Array")]
    [Benchmark(Baseline = true)]
    public int Array_foreach()
    {
        var sum = 0;
        foreach (var item in array!)
            sum += item;
        return sum;
    }

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int Array_Sum()
        => array!.Sum();

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int Array_MoreLinq()
    {
        var sum = 0;
        MoreLinq.MoreEnumerable.ForEach(array!, item => sum += item);
        return sum;
    }

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int Array_ForEachEx_Action()
    {
        var sum = 0;
        array!.ForEachEx(item => sum += item);
        return sum;
    }

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int Array_ForEachEx_ValueAction()
    {
        var sum = new SumValueAction<int>();
        array!.ForEachEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int Array_ForEachVectorEx()
    {
        var sum = new SumValueAction<int>();
        array!.ForEachVectorEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int ArrayAsEnumerable_ForEachEx_Action()
    {
        var sum = 0;
        ((IEnumerable<int>)array!).ForEachEx(item => sum += item);
        return sum;
    }

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int ArrayAsEnumerable_ForEachEx_ValueAction()
    {
        var sum = new SumValueAction<int>();
        ((IEnumerable<int>)array!).ForEachEx(ref sum);
        return sum.Result;
    }

    [BenchmarkCategory("Array")]
    [Benchmark]
    public int ArrayAsEnumerable_ForEachVectorEx()
    {
        var sum = new SumValueAction<int>();
        ((IEnumerable<int>)array!).ForEachVectorEx(ref sum);
        return sum.Result;
    }
}


