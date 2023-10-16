#if NET7_0_OR_GREATER // Requires C# 7.0+ for IAdditiveIdentity<T, T> and IAdditionOperators<T, T, T>

using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric
{
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
    public struct SumValueAction<T> : IVectorAction<T>
        where T : struct, IAdditiveIdentity<T, T>, IAdditionOperators<T, T, T>
    {
        T sum;
        Vector<T> sumVector;

        /// <summary>
        /// Initializes a new instance of the <see cref="SumValueAction{T}"/> struct.
        /// The initial sum value is set to the additive identity element of type <typeparamref name="T"/>.
        /// </summary>
        public SumValueAction()
        {
            sum = T.AdditiveIdentity;
            sumVector = Vector<T>.Zero;
        }

        /// <summary>
        /// Gets the current sum value of type <typeparamref name="T"/>.
        /// </summary>
        public readonly T Result
            => Vector.Sum(sumVector) + sum;

        /// <summary>
        /// Invokes the action with a readonly reference to the specified argument of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="item">The readonly reference to the argument of type <typeparamref name="T"/> to be processed by the action.</param>
        /// <remarks>
        /// This method performs an operation by adding the provided argument to an internal accumulator. The use of a readonly reference
        /// ensures that the provided argument is not modified during the operation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref readonly T item) 
            => sum += item;

        /// <summary>
        /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="vector">The readonly reference to the <see cref="Vector{T}"/> argument to be processed by the action.</param>
        /// <remarks>
        /// This method performs a vectorized operation by adding the elements of the provided <see cref="Vector{T}"/> to an internal accumulator.
        /// The use of a readonly reference ensures that the provided vector is not modified during the operation.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(ref readonly Vector<T> vector)
            => sumVector += vector;
    }
}

#endif
