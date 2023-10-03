using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

public static partial class Extensions
{
    public static void ForEachEx<T, TAction>(this IEnumerable<T> source, ref TAction action)
        where TAction : struct, IAction<T>
    {
        if (source.GetType() == typeof(T[]))
        {
            ForEachEx(Unsafe.As<T[]>(source), ref action);
        }
        else if (source.GetType() == typeof(List<T>))
        {
            ForEachEx(Unsafe.As<List<T>>(source), ref action);
        }
        else
        {
            foreach (var item in source)
                action.Invoke(item);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this List<T> source, ref TAction action)
        where TAction : struct, IAction<T>
        => CollectionsMarshal.AsSpan(Unsafe.As<List<T>>(source)).ForEachEx(ref action);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this T[] source, ref TAction action)
        where TAction : struct, IAction<T>
        => source.AsSpan().ForEachEx(ref action);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this Span<T> source, ref TAction action)
        where TAction : struct, IAction<T>
        => ((ReadOnlySpan<T>)source).ForEachEx(ref action);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEachEx<T, TAction>(this ReadOnlySpan<T> source, ref TAction action)
        where TAction : struct, IAction<T>
    {
        foreach (ref readonly var item in source)
            action.Invoke(item);
    }
}