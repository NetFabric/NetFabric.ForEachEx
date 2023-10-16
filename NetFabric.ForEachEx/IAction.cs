using System.Numerics;

namespace NetFabric;

/// <summary>
/// Represents an interface for a generic action that can be invoked with a readonly reference to an argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the argument to be passed when invoking the action.</typeparam>
public interface IAction<T>
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the argument to be passed to the action.</param>
    void Invoke(ref readonly T arg);
}

/// <summary>
/// Represents an interface for a generic action that can be invoked with a readonly reference to a <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Vector{T}"/> argument.</typeparam>
/// <remarks>
/// This interface extends the <see cref="IAction{T}"/> interface to support vectorized operations. It allows actions to be invoked
/// with a readonly reference to a <see cref="Vector{T}"/> argument, making it suitable for scenarios where vectorization can be applied
/// for improved performance in numerical or computational tasks.
/// </remarks>
public interface IVectorAction<T> : IAction<T>
    where T : struct
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the <see cref="Vector{T}"/> argument to be passed to the action.</param>
    void Invoke(ref readonly Vector<T> arg);
}
