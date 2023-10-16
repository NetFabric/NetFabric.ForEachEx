namespace NetFabric.ForEachEx.UnitTests;

public class ForEachExValueActionTests
{
    public static TheoryData<IEnumerable<int>> Data => new()
    {
        Enumerable.Empty<int>(),
        Enumerable.Range(1, 1),
        Enumerable.Range(0, 10),
        Enumerable.Range(0, 100).Where(item => item % 2 == 0),
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_Enumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new MoqValueAction<int>();

        // act
        source.ForEachEx(ref action);

        // assert
        Assert.Equal(source, action.Values);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_List_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new MoqValueAction<int>();
        var list = source.ToList();

        // act
        list.ForEachEx(ref action);

        // assert
        Assert.Equal(source, action.Values);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_List_AsEnumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new MoqValueAction<int>();
        var enumerable = source.ToList() as IEnumerable<int>;

        // act
        enumerable.ForEachEx(ref action);

        // assert
        Assert.Equal(source, action.Values);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_Array_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new MoqValueAction<int>();
        var array = source.ToArray();

        // act
        array.ForEachEx(ref action);

        // assert
        Assert.Equal(source, action.Values);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_Array_AsEnumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new MoqValueAction<int>();
        var enumerable = source.ToArray() as IEnumerable<int>;

        // act
        enumerable.ForEachEx(ref action);

        // assert
        Assert.Equal(source, action.Values);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_Span_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new MoqValueAction<int>();
        var span = source.ToArray().AsSpan();

        // act
        span.ForEachEx(ref action);

        // assert
        Assert.Equal(source, action.Values);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_ReadOnlySpan_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var action = new MoqValueAction<int>();
        var span = (ReadOnlySpan<int>)source.ToArray().AsSpan();

        // act
        span.ForEachEx(ref action);

        // assert
        Assert.Equal(source, action.Values);
    }
}