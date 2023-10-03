using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

[StructLayout(LayoutKind.Auto)]
public readonly struct ConsoleWriteLineValueAction<T>
    : IAction<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(T item)
        => Console.WriteLine(item);
}
