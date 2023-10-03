using System.Runtime.CompilerServices;

namespace NetFabric.ForEach.UnitTests;

struct MoqValueAction<T> : IAction<T>
    where T : struct
{
    List<T> values;

    public MoqValueAction()
    {
        values = new List<T>();
    }

    public IReadOnlyList<T> Values 
        => values;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(T arg) 
        => values.Add(arg);
}
