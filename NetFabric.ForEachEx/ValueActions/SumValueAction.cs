#if NET7_0_OR_GREATER // Requires C# 7.0+ for IAdditiveIdentity<T, T> and IAdditionOperators<T, T, T>

using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

/// <summary>
/// Represents a mutable struct that implements the <see cref="IAction{T}"/> interface.
/// This struct is specialized for types that support addition operations and provide an additive identity.
/// It allows accumulating and computing the sum of values of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">
/// The type of values to be summed. It must be a value type that implements the required interfaces:
/// - <see cref="IAdditiveIdentity{T, T}"/> to provide an additive identity element.
/// - <see cref="IAdditionOperators{T, T, T}"/> to support addition operations.
/// </typeparam>
[StructLayout(LayoutKind.Auto)]
public struct SumValueAction<T> : IAction<T>
    where T : struct, IAdditiveIdentity<T, T>, IAdditionOperators<T, T, T>
{
#pragma warning disable IDE0032 // Use auto property
    T sum;
#pragma warning restore IDE0032 // Use auto property

    /// <summary>
    /// Initializes a new instance of the <see cref="SumValueAction{T}"/> struct.
    /// The initial sum value is set to the additive identity element of type <typeparamref name="T"/>.
    /// </summary>
    public SumValueAction()
    {
        sum = T.AdditiveIdentity;
    }

    /// <summary>
    /// Gets the current sum value of type <typeparamref name="T"/>.
    /// </summary>
    public readonly T Result
        => sum;

    /// <summary>
    /// Accumulates the specified item into the current sum value.
    /// </summary>
    /// <param name="item">The item to be added to the sum.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(ref readonly T item)
        => sum += item;
}

#endif