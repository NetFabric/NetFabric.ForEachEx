using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

public class UnrollBenchmarks
{
    int[]? array;

    [Params(10, 1_000_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var enumerable = Utils.GetEnumerable(Count, 100);
        array = enumerable.ToArray();
    }

    [Benchmark(Baseline = true)]
    public int Baseline()
    {
        var sum = 0;
        foreach(var item in array!)
            sum += item;
        return sum;
    }

    [Benchmark]
    public int Unrolled()
    {
        var source = array.AsSpan();
        ref var sourceRef = ref MemoryMarshal.GetReference(source);

        var sum = 0;
#if NET7_0_OR_GREATER
        var index = nint.Zero;
#else
        var index = (nint)0;
#endif
        var end = source.Length - (source.Length % 4);
        while (index < end)
        {
            sum += Unsafe.Add(ref sourceRef, index);
            sum += Unsafe.Add(ref sourceRef, index + 1);
            sum += Unsafe.Add(ref sourceRef, index + 2);
            sum += Unsafe.Add(ref sourceRef, index + 3);

            index += 4;
        }

        // handle remaining elements
        while (index < source.Length)
        {
            sum += Unsafe.Add(ref sourceRef, index);

            index++;
        }

        return sum;
    }
}


