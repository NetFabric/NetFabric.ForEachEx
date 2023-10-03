namespace NetFabric;

public static partial class Extensions
{
    /// <summary>
    /// Executes the specified action for each element in the source collection of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="source">The source collection to iterate over.</param>
    /// <param name="action">The action to be executed for each element.</param>
    /// <remarks>
    /// This method is designed to simplify iterating through a collection and applying the specified action to each element.
    /// </remarks>
    public static void ForEachEx<T>(this IEnumerable<T> source, Action<T> action)
    {
        var actionWrapper = new ActionWrapperValueAction<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    /// <summary>
    /// Executes the specified action for each element in the source List of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the List.</typeparam>
    /// <param name="source">The source List to iterate over.</param>
    /// <param name="action">The action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through a List and applying the specified action to each element.
    /// </remarks>
    public static void ForEachEx<T>(this List<T> source, Action<T> action)
    {
        var actionWrapper = new ActionWrapperValueAction<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    /// <summary>
    /// Executes the specified action for each element in the source array of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="source">The source array to iterate over.</param>
    /// <param name="action">The action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through an array and applying the specified action to each element.
    /// </remarks>
    public static void ForEachEx<T>(this T[] source, Action<T> action)
    {
        var actionWrapper = new ActionWrapperValueAction<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    /// <summary>
    /// Executes the specified action for each element in the source Span of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the Span.</typeparam>
    /// <param name="source">The source Span to iterate over.</param>
    /// <param name="action">The action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through a Span and applying the specified action to each element.
    /// </remarks>
    public static void ForEachEx<T>(this Span<T> source, Action<T> action)
    {
        var actionWrapper = new ActionWrapperValueAction<T>(action);
        source.ForEachEx(ref actionWrapper);
    }

    /// <summary>
    /// Executes the specified action for each element in the source ReadOnlySpan of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the ReadOnlySpan.</typeparam>
    /// <param name="source">The source ReadOnlySpan to iterate over.</param>
    /// <param name="action">The action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through a ReadOnlySpan and applying the specified action to each element.
    /// </remarks>
    public static void ForEachEx<T>(this ReadOnlySpan<T> source, Action<T> action)
    {
        var actionWrapper = new ActionWrapperValueAction<T>(action);
        source.ForEachEx(ref actionWrapper);
    }
}
