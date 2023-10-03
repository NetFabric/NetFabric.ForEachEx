# NetFabric.ForEachEx

## Overview

The NetFabric.ForEachEx package is a valuable addition to your .NET projects that enhances the functionality of the `ForEach` method, specifically designed for enumerables. With this package, you can seamlessly apply the `ForEachEx` method to various enumerable types, making your code cleaner, more concise, and more efficient.

## Features

- **Universal `ForEachEx`**: Apply the `ForEachEx` method to a wide range of enumerable types, including lists, arrays, spans, and more, simplifying your iteration code.

- **Improved Readability**: Simplify your code by using a consistent `ForEachEx` syntax across different enumerable types, making it more readable and maintainable.

- **Custom Value Actions**: Easily create custom value actions to perform operations on enumerable elements efficiently, all while avoiding heap allocations.

## Installation

You can easily add the NetFabric.ForEachEx package to your .NET project using NuGet Package Manager. Simply run the following command in your project directory:

```bash
dotnet add package NetFabric.ForEachEx
```

## Usage

Using NetFabric.ForEachEx is straightforward. First, ensure you've added the package to your project as described in the installation section.

Then, you can import the `NetFabric` namespace and start using the enhanced `ForEachEx` method with various enumerable types:

```csharp
using NetFabric;

// ...

var myList = new List<int> { 1, 2, 3, 4, 5 };

myList.ForEachEx(item => Console.WriteLine(item));
```

The `ForEachEx` method is now available for enumerable types, allowing you to iterate through and operate on their elements with ease.

Additionally, you can take advantage of custom value actions to perform specific operations on enumerable elements. Here's an example of how to create and use a custom value action:

```csharp
using NetFabric;

// Define a custom value action
public struct CustomValueAction<T> : IAction<T>
{
    private int count;

    public CustomValueAction(int initialCount)
    {
        count = initialCount;
    }

    public void Invoke(T item)
    {
        // Implement your custom action here
        Console.WriteLine($"Item {count}: {item}");
        count++;
    }
}

// ...

var values = new List<int> { 10, 20, 30, 40, 50 };

var customAction = new CustomValueAction<int>(1);
values.ForEachEx(customAction); // Apply the custom action to the enumerable
```

In this example, the `CustomValueAction<T>` struct is implemented to perform a custom action on each element of the `values` enumerable. You can define your logic inside the `Invoke` method of your custom value action.

With the NetFabric.ForEachEx package, you can easily apply the `ForEachEx` method to various enumerable types while also benefiting from the fact that value actions do not allocate on the heap, unlike lambda expressions. This can lead to improved memory efficiency in your code.

## Contribution

Contributions are welcome! If you encounter issues or have suggestions for improvements, please feel free to open an issue or submit a pull request on our GitHub repository.

## License

This package is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
