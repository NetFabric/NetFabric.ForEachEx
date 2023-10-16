using System.Runtime.CompilerServices;

namespace NetFabric.ForEachEx.UnitTests;

struct MoqValueAction<T> : IAction<T>
    where T : struct
{
    readonly List<T> values;

    public MoqValueAction()
    {
        values = new List<T>();
    }

    public IReadOnlyList<T> Values
        => values;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Invoke(ref readonly T arg)
        => values.Add(arg);
}

