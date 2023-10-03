#if NET7_0_OR_GREATER

using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

[StructLayout(LayoutKind.Auto)]
public struct SumAction<T>
    : IAction<T>
    where T : struct, IAdditiveIdentity<T, T>, IAdditionOperators<T, T, T>
{
#pragma warning disable IDE0032 // Use auto property
    T sum;
#pragma warning restore IDE0032 // Use auto property

    public SumAction()
    {
        sum = T.AdditiveIdentity;
    }

    public readonly T Result
        => sum;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(T item)
        => sum += item;
}

#endif