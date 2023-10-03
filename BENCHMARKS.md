```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3516/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.100-rc.1.23463.5
  [Host]     : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
| Method                                  | Categories | Count | Mean         | Error       | StdDev      | Median       | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |----------- |------ |-------------:|------------:|------------:|-------------:|--------------:|--------:|-------:|----------:|------------:|
| **Array_foreach**                           | **Array**      | **10**    |     **3.165 ns** |   **0.1278 ns** |   **0.3542 ns** |     **3.090 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| Array_Sum                               | Array      | 10    |     5.922 ns |   0.2107 ns |   0.6148 ns |     5.770 ns |  1.89x slower |   0.27x |      - |         - |          NA |
| Array_MoreLinq                          | Array      | 10    |    40.621 ns |   0.9513 ns |   2.6831 ns |    39.916 ns | 12.99x slower |   1.62x | 0.0573 |     120 B |          NA |
| Array_ForEachEx_Action                  | Array      | 10    |    24.855 ns |   0.5247 ns |   0.7005 ns |    24.637 ns |  7.47x slower |   0.76x | 0.0421 |      88 B |          NA |
| Array_ForEachEx_ValueAction             | Array      | 10    |     2.925 ns |   0.1120 ns |   0.3249 ns |     2.774 ns |  1.09x faster |   0.16x |      - |         - |          NA |
| ArrayAsEnumerable_ForEachEx_Action      | Array      | 10    |    25.850 ns |   0.5054 ns |   0.7718 ns |    25.554 ns |  7.98x slower |   0.97x | 0.0421 |      88 B |          NA |
| ArrayAsEnumerable_ForEachEx_ValueAction | Array      | 10    |     9.106 ns |   0.0974 ns |   0.0760 ns |     9.082 ns |  2.75x slower |   0.32x |      - |         - |          NA |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **Array_foreach**                           | **Array**      | **1000**  |   **363.990 ns** |   **6.5500 ns** |  **10.1976 ns** |   **358.989 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| Array_Sum                               | Array      | 1000  |    89.811 ns |   1.1836 ns |   0.9240 ns |    89.485 ns |  4.09x faster |   0.15x |      - |         - |          NA |
| Array_MoreLinq                          | Array      | 1000  | 1,643.405 ns |  27.6229 ns |  28.3667 ns | 1,633.977 ns |  4.52x slower |   0.15x | 0.0572 |     120 B |          NA |
| Array_ForEachEx_Action                  | Array      | 1000  | 1,289.325 ns |  12.4801 ns |   9.7436 ns | 1,287.452 ns |  3.52x slower |   0.12x | 0.0420 |      88 B |          NA |
| Array_ForEachEx_ValueAction             | Array      | 1000  |   363.028 ns |   6.9799 ns |  11.4682 ns |   357.249 ns |  1.00x faster |   0.03x |      - |         - |          NA |
| ArrayAsEnumerable_ForEachEx_Action      | Array      | 1000  | 1,271.476 ns |   6.3036 ns |   4.9214 ns | 1,269.616 ns |  3.47x slower |   0.11x | 0.0420 |      88 B |          NA |
| ArrayAsEnumerable_ForEachEx_ValueAction | Array      | 1000  | 1,546.416 ns |   5.8335 ns |   5.4567 ns | 1,547.096 ns |  4.24x slower |   0.13x |      - |         - |          NA |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **Enumerable_foreach**                      | **Enumerable** | **10**    |   **504.958 ns** |   **9.2312 ns** |  **12.0032 ns** |   **500.730 ns** |      **baseline** |        **** | **0.1678** |     **352 B** |            **** |
| Enumerable_Sum                          | Enumerable | 10    |   503.057 ns |   3.8949 ns |   3.4527 ns |   501.861 ns |  1.01x faster |   0.03x | 0.1678 |     352 B |  1.00x more |
| Enumerable_MoreLinq                     | Enumerable | 10    |   504.057 ns |   4.0880 ns |   3.4137 ns |   503.671 ns |  1.01x faster |   0.03x | 0.2098 |     440 B |  1.25x more |
| Enumerable_ForEachEx_Action             | Enumerable | 10    |   518.498 ns |   9.6424 ns |  14.4323 ns |   512.488 ns |  1.03x slower |   0.04x | 0.2098 |     440 B |  1.25x more |
| Enumerable_ForEachEx_ValueAction        | Enumerable | 10    |   515.873 ns |  10.3145 ns |  24.7129 ns |   509.644 ns |  1.02x slower |   0.05x | 0.1678 |     352 B |  1.00x more |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **Enumerable_foreach**                      | **Enumerable** | **1000**  | **5,720.523 ns** | **121.1572 ns** | **343.7029 ns** | **5,636.525 ns** |      **baseline** |        **** | **0.1678** |     **352 B** |            **** |
| Enumerable_Sum                          | Enumerable | 1000  | 6,558.582 ns | 131.1656 ns | 367.8023 ns | 6,435.955 ns |  1.15x slower |   0.08x | 0.1678 |     352 B |  1.00x more |
| Enumerable_MoreLinq                     | Enumerable | 1000  | 5,327.473 ns | 120.3491 ns | 343.3626 ns | 5,206.678 ns |  1.08x faster |   0.10x | 0.2060 |     440 B |  1.25x more |
| Enumerable_ForEachEx_Action             | Enumerable | 1000  | 5,898.580 ns | 115.2227 ns | 189.3142 ns | 5,825.275 ns |  1.04x slower |   0.07x | 0.2060 |     440 B |  1.25x more |
| Enumerable_ForEachEx_ValueAction        | Enumerable | 1000  | 5,046.548 ns |  95.6847 ns | 241.8075 ns | 4,929.405 ns |  1.13x faster |   0.09x | 0.1678 |     352 B |  1.00x more |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **List_foreach**                            | **List**       | **10**    |     **7.159 ns** |   **0.1454 ns** |   **0.1891 ns** |     **7.080 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| List_foreach_AsSpan                     | List       | 10    |     3.432 ns |   0.0604 ns |   0.1026 ns |     3.407 ns |  2.08x faster |   0.09x |      - |         - |          NA |
| List_Sum                                | List       | 10    |     5.035 ns |   0.1230 ns |   0.1643 ns |     4.961 ns |  1.42x faster |   0.07x |      - |         - |          NA |
| List_ForEach                            | List       | 10    |    26.031 ns |   0.5061 ns |   1.0224 ns |    25.575 ns |  3.65x slower |   0.18x | 0.0421 |      88 B |          NA |
| List_MoreLinq                           | List       | 10    |    43.706 ns |   0.7526 ns |   0.5876 ns |    43.557 ns |  6.10x slower |   0.23x | 0.0612 |     128 B |          NA |
| List_ForEachEx_Action                   | List       | 10    |    24.690 ns |   0.5249 ns |   0.9729 ns |    24.261 ns |  3.47x slower |   0.19x | 0.0421 |      88 B |          NA |
| List_ForEachEx_ValueAction              | List       | 10    |     4.379 ns |   0.1167 ns |   0.1297 ns |     4.348 ns |  1.64x faster |   0.06x |      - |         - |          NA |
| ListAsEnumerable_ForEachEx_Action       | List       | 10    |    24.397 ns |   0.5040 ns |   1.4380 ns |    23.663 ns |  3.45x slower |   0.25x | 0.0421 |      88 B |          NA |
| ListAsEnumerable_ForEachEx_ValueAction  | List       | 10    |     7.105 ns |   0.1173 ns |   0.0915 ns |     7.088 ns |  1.01x faster |   0.04x |      - |         - |          NA |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **List_foreach**                            | **List**       | **1000**  |   **593.966 ns** |  **11.9187 ns** |  **20.2388 ns** |   **585.320 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| List_foreach_AsSpan                     | List       | 1000  |   366.504 ns |   7.0565 ns |  12.9032 ns |   359.582 ns |  1.62x faster |   0.07x |      - |         - |          NA |
| List_Sum                                | List       | 1000  |    90.099 ns |   0.9701 ns |   0.8101 ns |    89.834 ns |  6.71x faster |   0.32x |      - |         - |          NA |
| List_ForEach                            | List       | 1000  | 1,385.749 ns |  26.5044 ns |  27.2181 ns | 1,370.509 ns |  2.32x slower |   0.10x | 0.0420 |      88 B |          NA |
| List_MoreLinq                           | List       | 1000  | 2,098.207 ns |  41.7633 ns |  39.0654 ns | 2,078.510 ns |  3.50x slower |   0.16x | 0.0610 |     128 B |          NA |
| List_ForEachEx_Action                   | List       | 1000  | 1,284.038 ns |   7.1180 ns |   5.5572 ns | 1,281.785 ns |  2.12x slower |   0.10x | 0.0420 |      88 B |          NA |
| List_ForEachEx_ValueAction              | List       | 1000  |   363.519 ns |   7.0121 ns |   9.5983 ns |   358.827 ns |  1.63x faster |   0.08x |      - |         - |          NA |
| ListAsEnumerable_ForEachEx_Action       | List       | 1000  | 1,292.732 ns |  24.8887 ns |  26.6307 ns | 1,281.496 ns |  2.16x slower |   0.10x | 0.0420 |      88 B |          NA |
| ListAsEnumerable_ForEachEx_ValueAction  | List       | 1000  | 1,549.408 ns |   7.4307 ns |   6.9507 ns | 1,552.172 ns |  2.58x slower |   0.10x |      - |         - |          NA |
