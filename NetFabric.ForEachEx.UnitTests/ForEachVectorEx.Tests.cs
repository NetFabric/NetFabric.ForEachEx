namespace NetFabric.ForEachVectorEx.UnitTests;

public class ForEachVectorExTests
{
    public static TheoryData<IEnumerable<int>> Data => new()
    {
        Enumerable.Empty<int>(),
        Enumerable.Range(1, 1),
        Enumerable.Range(1, 5),
        Enumerable.Range(0, 10),
        Enumerable.Range(0, 100).Where(item => item % 2 == 0),
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachVectorEx_On_Enumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new SumValueAction<int>();
        var expected = source.Sum();

        // act
        source.ForEachVectorEx(ref action);

        // assert
        Assert.Equal(expected, action.Result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachVectorEx_On_List_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new SumValueAction<int>();
        var list = source.ToList();
        var expected = source.Sum();

        // act
        list.ForEachVectorEx(ref action);

        // assert
        Assert.Equal(expected, action.Result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachVectorEx_On_List_AsEnumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new SumValueAction<int>();
        var enumerable = source.ToList() as IEnumerable<int>;
        var expected = source.Sum();

        // act
        enumerable.ForEachVectorEx(ref action);

        // assert
        Assert.Equal(expected, action.Result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachVectorEx_On_Array_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new SumValueAction<int>();
        var array = source.ToArray();
        var expected = source.Sum();

        // act
        array.ForEachVectorEx(ref action);

        // assert
        Assert.Equal(expected, action.Result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachVectorEx_On_Array_AsEnumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new SumValueAction<int>();
        var enumerable = source.ToArray() as IEnumerable<int>;
        var expected = source.Sum();

        // act
        enumerable.ForEachVectorEx(ref action);

        // assert
        Assert.Equal(expected, action.Result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachVectorEx_On_Span_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new SumValueAction<int>();
        var span = source.ToArray().AsSpan();
        var expected = source.Sum();

        // act
        span.ForEachVectorEx(ref action);

        // assert
        Assert.Equal(expected, action.Result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachVectorEx_On_ReadOnlySpan_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new SumValueAction<int>();
        var span = (ReadOnlySpan<int>)source.ToArray().AsSpan();
        var expected = source.Sum();

        // act
        span.ForEachVectorEx(ref action);

        // assert
        Assert.Equal(expected, action.Result);
    }
}