﻿static class Utils
{
    public static IEnumerable<int> GetEnumerable(int count)
    {
        var random = new Random(42);
        for (var item = 0; item < count; item++)
            yield return random.Next(count);
    }
}
