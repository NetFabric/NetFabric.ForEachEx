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


