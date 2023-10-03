namespace NetFabric;

/// <summary>
/// Represents an interface for a generic action that can be invoked with an argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the argument to be passed when invoking the action.</typeparam>
public interface IAction<in T>
{
    /// <summary>
    /// Invokes the action with the specified argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The argument to be passed to the action.</param>
    void Invoke(T arg);
}

