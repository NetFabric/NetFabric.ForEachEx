using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

public static partial class Extensions
{
    /// <summary>
    /// Efficiently applies a custom action to each element in a collection of type <typeparamref name="T"/>
    /// using vectorization (SIMD) for improved performance (where supported and on compatible hardware).
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IVectorAction{T}"/> interface.</typeparam>
    /// <param name="source">The collection to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method streamlines the process of iterating through a collection and applying a custom action to each element
    /// efficiently by leveraging vectorization (SIMD) for enhanced performance on supported types and compatible hardware.
    /// </remarks>
    public static void ForEachVectorEx<T, TAction>(this IEnumerable<T> source, ref TAction action)
        where T : struct
        where TAction : struct, IVectorAction<T>
    {
        if (source.GetType() == typeof(T[]))
        {
            Unsafe.As<T[]>(source).ForEachEx(ref action);
        }
        else if (source.GetType() == typeof(List<T>))
        {
            Unsafe.As<List<T>>(source).ForEachEx(ref action);
        }
        else
        {
            foreach (var item in source)
                action.Invoke(in item);
        }
    }

    /// <summary>
    /// Efficiently applies a custom action to each element in a List of type <typeparamref name="T"/>
    /// using vectorization (SIMD) for improved performance (where supported and on compatible hardware).
    /// </summary>
    /// <typeparam name="T">The type of elements in the List.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IVectorAction{T}"/> interface.</typeparam>
    /// <param name="source">The List to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through a List and applying a custom action to each element
    /// efficiently by utilizing vectorization (SIMD) for enhanced performance on supported types and compatible hardware.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachVectorEx<T, TAction>(this List<T> source, ref TAction action)
        where T : struct
        where TAction : struct, IVectorAction<T>
        => CollectionsMarshal.AsSpan(source).ForEachVectorEx(ref action);

    /// <summary>
    /// Efficiently applies a custom action to each element in an array of type <typeparamref name="T"/>
    /// using vectorization (SIMD) for improved performance (where supported and on compatible hardware).
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IVectorAction{T}"/> interface.</typeparam>
    /// <param name="source">The array to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method simplifies the process of iterating through an array and applying a custom action to each element
    /// efficiently by making use of vectorization (SIMD) for enhanced performance on supported types and compatible hardware.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachVectorEx<T, TAction>(this T[] source, ref TAction action)
        where T : struct
        where TAction : struct, IVectorAction<T>
        => source.AsSpan().ForEachVectorEx(ref action);

    /// <summary>
    /// Efficiently applies a custom action to each element in a Span of type <typeparamref name="T"/>
    /// using vectorization (SIMD) for improved performance (where supported and on compatible hardware).
    /// </summary>
    /// <typeparam name="T">The type of elements in the Span.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IVectorAction{T}"/> interface.</typeparam>
    /// <param name="source">The Span to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method streamlines the process of iterating through a Span and applying a custom action to each element
    /// efficiently by leveraging vectorization (SIMD) for enhanced performance on supported types and compatible hardware.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachVectorEx<T, TAction>(this Span<T> source, ref TAction action)
        where T : struct
        where TAction : struct, IVectorAction<T>
        => ((ReadOnlySpan<T>)source).ForEachVectorEx(ref action);

    /// <summary>
    /// Efficiently applies a custom action to each element in a ReadOnlySpan of type <typeparamref name="T"/>
    /// using vectorization (SIMD) for improved performance (where supported and on compatible hardware).
    /// </summary>
    /// <typeparam name="T">The type of elements in the ReadOnlySpan.</typeparam>
    /// <typeparam name="TAction">The custom action type implementing the <see cref="IVectorAction{T}"/> interface.</typeparam>
    /// <param name="source">The ReadOnlySpan to iterate over.</param>
    /// <param name="action">A reference to the custom action to be executed for each element.</param>
    /// <remarks>
    /// This method streamlines the process of iterating through a ReadOnlySpan and applying a custom action to each element
    /// efficiently by leveraging vectorization (SIMD) for enhanced performance on supported types and compatible hardware.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachVectorEx<T, TAction>(this ReadOnlySpan<T> source, ref TAction action)
        where T : struct
        where TAction : struct, IVectorAction<T>
    {
        // Check if hardware acceleration is available and supported data types for SIMD operations.
        if (Vector.IsHardwareAccelerated &&
#if NET7_0_OR_GREATER
            Vector<T>.IsSupported &&
#endif
            source.Length > Vector<T>.Count)
        {
            // Cast the source span into vectors of the specified data type.
            var vectors = MemoryMarshal.Cast<T, Vector<T>>(source);

            // Iterate through the vectors and invoke the action on each vector.
            foreach (ref readonly var vector in vectors)
                action.Invoke(in vector);

            // Calculate the remaining elements after processing vectors.
            var remaining = source.Length % Vector<T>.Count;

            // Reduce the source span to the remaining elements for further processing.
            source = source[^remaining..];
        }

        // Iterate through the remaining elements (or all elements if not using SIMD operations)
        // and invoke the action on each individual element.
        foreach (ref readonly var item in source)
        {
            action.Invoke(in item);
        }
    }

}
