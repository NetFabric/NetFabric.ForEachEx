using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

[StructLayout(LayoutKind.Auto)]
readonly struct ActionWrapper<T>
    : IAction<T>
{
    readonly Action<T> action;

    public ActionWrapper(Action<T> action)
        => this.action = action;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(T arg)
        => action(arg);
}
