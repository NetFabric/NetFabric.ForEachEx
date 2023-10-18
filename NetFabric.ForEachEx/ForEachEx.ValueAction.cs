using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

public static partial class Extensions
{
    /// <summary>
    /// Executes the specified custom action for each element in the source collection of type <typeparamref name="T"/>
    /// using a value-based action implementation for minimized overhead.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IAction{T}"/> interface.</typeparam>
    /// <param name="source">The source collection to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method enables custom actions to be applied to each element in a collection efficiently
    /// by using a value-based action implementation, minimizing overhead.
    /// </remarks>
    public static void ForEachEx<T, TAction>(this IEnumerable<T> source, ref TAction action)
        where TAction : struct, IAction<T>
    {
        if (source.TryGetSpan(out var span))
        {
            span.ForEachEx(ref action);
        }
        else
        {
            foreach (var item in source)
                action.Invoke(in item);
        }
    }

    /// <summary>
    /// Executes the specified custom action for each element in the source List of type <typeparamref name="T"/>
    /// using a value-based action implementation for minimized overhead.
    /// </summary>
    /// <typeparam name="T">The type of elements in the List.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IAction{T}"/> interface.</typeparam>
    /// <param name="source">The source List to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through a List and applying a custom action to each element
    /// efficiently by using a value-based action implementation, minimizing overhead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this List<T> source, ref TAction action)
        where TAction : struct, IAction<T>
        => CollectionsMarshal.AsSpan(source).ForEachEx(ref action);

    /// <summary>
    /// Executes the specified custom action for each element in the source array of type <typeparamref name="T"/>
    /// using a value-based action implementation for minimized overhead.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IAction{T}"/> interface.</typeparam>
    /// <param name="source">The source array to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through an array and applying a custom action to each element
    /// efficiently by using a value-based action implementation, minimizing overhead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this T[] source, ref TAction action)
        where TAction : struct, IAction<T>
        => source.AsSpan().ForEachEx(ref action);

    /// <summary>
    /// Executes the specified custom action for each element in the source Span of type <typeparamref name="T"/>
    /// using a value-based action implementation for minimized overhead.
    /// </summary>
    /// <typeparam name="T">The type of elements in the Span.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IAction{T}"/> interface.</typeparam>
    /// <param name="source">The source Span to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through a Span and applying a custom action to each element
    /// efficiently by using a value-based action implementation, minimizing overhead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this Span<T> source, ref TAction action)
        where TAction : struct, IAction<T>
        => ((ReadOnlySpan<T>)source).ForEachEx(ref action);

    /// <summary>
    /// Executes the specified custom action for each element in the source ReadOnlySpan of type <typeparamref name="T"/>
    /// using a value-based action implementation for minimized overhead.
    /// </summary>
    /// <typeparam name="T">The type of elements in the ReadOnlySpan.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IAction{T}"/> interface.</typeparam>
    /// <param name="source">The source ReadOnlySpan to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through a ReadOnlySpan and applying a custom action to each element
    /// efficiently by using a value-based action implementation, minimizing overhead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this ReadOnlySpan<T> source, ref TAction action)
        where TAction : struct, IAction<T>
    {
        foreach (ref readonly var item in source)
            action.Invoke(in item);
    }
}
