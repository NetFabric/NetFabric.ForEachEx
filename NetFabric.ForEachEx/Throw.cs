using System.Diagnostics.CodeAnalysis;

namespace NetFabric;

[ExcludeFromCodeCoverage]
static class Throw
{
    [DoesNotReturn]
    public static void ArgumentNullException(string parameterName, string? message = default)
        => throw new ArgumentNullException(paramName: parameterName, message: message);

    [DoesNotReturn]
    public static T ArgumentNullException<T>(string parameterName, string? message = default)
        => throw new ArgumentNullException(paramName: parameterName, message: message);
}