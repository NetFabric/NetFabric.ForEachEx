using System.Runtime.CompilerServices;

namespace NetFabric.ForEachEx.UnitTests;

readonly struct MoqValueAction<T> : IAction<T>
{
    readonly List<T> values;

    public MoqValueAction() 
        => values = [];

    public IReadOnlyList<T> Values
        => values;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    readonly void IAction<T>.Invoke(ref readonly T arg)
            => values.Add(arg);
}

