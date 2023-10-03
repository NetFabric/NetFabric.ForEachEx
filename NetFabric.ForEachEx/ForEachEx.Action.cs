namespace NetFabric;

public static partial class Extensions
{
    public static void ForEachEx<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (action is null)
            Throw.ArgumentNullException(nameof(action));    
        var actionWrapper = new ActionWrapper<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    public static void ForEachEx<T>(this List<T> source, Action<T> action)
    {
        if (action is null)
            Throw.ArgumentNullException(nameof(action));
        var actionWrapper = new ActionWrapper<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    public static void ForEachEx<T>(this T[] source, Action<T> action)
    {
        if (action is null)
            Throw.ArgumentNullException(nameof(action));
        var actionWrapper = new ActionWrapper<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    public static void ForEachEx<T>(this Span<T> source, Action<T> action)
    {
        if (action is null)
            Throw.ArgumentNullException(nameof(action));
        var actionWrapper = new ActionWrapper<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    public static void ForEachEx<T>(this ReadOnlySpan<T> source, Action<T> action)
    {
        if (action is null)
            Throw.ArgumentNullException(nameof(action));
        var actionWrapper = new ActionWrapper<T>(action);
        source.ForEachEx(ref actionWrapper);
    }
}