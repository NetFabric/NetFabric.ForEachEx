using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

/// <summary>
/// Represents a read-only struct that implements the <see cref="IAction{T}"/> interface
/// and provides a way to invoke the <see cref="Console.WriteLine"/> method with a specified value of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the item to be written to the console when invoked.</typeparam>
[StructLayout(LayoutKind.Auto)]
public readonly struct ConsoleWriteLineValueAction<T> : IAction<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T>.Invoke(ref readonly T item)
        => Console.WriteLine(item);
}
