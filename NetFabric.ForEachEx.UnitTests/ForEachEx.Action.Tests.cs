namespace NetFabric.ForEachEx.UnitTests;

public class ForEachExActionTests
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
        var result = new List<int>();

        // act
        source.ForEachEx(item => result.Add(item));

        // assert
        Assert.Equal(source, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_List_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var result = new List<int>();
        var list = source.ToList();

        // act
        list.ForEachEx(item => result.Add(item));

        // assert
        Assert.Equal(source, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_List_AsEnumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var result = new List<int>();
        var enumerable = source.ToList() as IEnumerable<int>;

        // act
        enumerable.ForEachEx(item => result.Add(item));

        // assert
        Assert.Equal(source, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_Array_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var result = new List<int>();
        var array = source.ToArray();

        // act
        array.ForEachEx(item => result.Add(item));

        // assert
        Assert.Equal(source, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_Array_AsEnumerable_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var result = new List<int>();
        var enumerable = source.ToArray() as IEnumerable<int>;

        // act
        enumerable.ForEachEx(item => result.Add(item));

        // assert
        Assert.Equal(source, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_Span_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var result = new List<int>();
        var span = source.ToArray().AsSpan();

        // act
        span.ForEachEx(item => result.Add(item));

        // assert
        Assert.Equal(source, result);
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void ForEachEx_On_ReadOnlySpan_Should_Succeed(IEnumerable<int> source)
    {
        // arrange
        var result = new List<int>();
        var span = (ReadOnlySpan<int>)source.ToArray().AsSpan();

        // act
        span.ForEachEx(item => result.Add(item));

        // assert
        Assert.Equal(source, result);
    }
}