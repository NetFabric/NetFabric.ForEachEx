﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric;

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T}"/> delegate
/// and implements the <see cref="IAction{T}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T">The type of the argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapperValueAction<T>(Action<T> action) : IAction<T>
{
    readonly Action<T> action = action ?? Throw.ArgumentNullException<Action<T>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T>.Invoke(ref readonly T arg)
        => action(arg);
}
