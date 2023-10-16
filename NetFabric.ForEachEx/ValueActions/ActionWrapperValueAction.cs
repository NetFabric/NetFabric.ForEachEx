using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T}"/> delegate
/// and implements the <see cref="IAction{T}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T">The type of the argument to be passed to the action when invoked.</typeparam>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapperValueAction<T> : IAction<T>
{
    readonly Action<T> action;

    /// <summary>
    /// Initializes a new instance of the <see cref="ActionWrapperValueAction{T}"/> struct with the specified action.
    /// </summary>
    /// <param name="action">The <see cref="Action{T}"/> delegate to be wrapped.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
    public ActionWrapperValueAction(Action<T> action)
        => this.action = action ?? Throw.ArgumentNullException<Action<T>>(nameof(action));

    /// <summary>
    /// Invokes the wrapped action with the specified argument.
    /// </summary>
    /// <param name="arg">The argument to be passed to the wrapped action.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Invoke(ref readonly T arg)
        => action(arg);
}
