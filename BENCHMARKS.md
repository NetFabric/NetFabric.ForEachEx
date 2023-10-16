```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3570/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.100-rc.2.23502.2
  [Host]     : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.47906), X64 RyuJIT AVX2


```
| Method                                  | Categories | Count | Mean         | Error       | StdDev      | Median       | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------------- |----------- |------ |-------------:|------------:|------------:|-------------:|--------------:|--------:|-------:|----------:|------------:|
| **Array_foreach**                           | **Array**      | **10**    |     **3.228 ns** |   **0.1224 ns** |   **0.3451 ns** |     **3.140 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| Array_Sum                               | Array      | 10    |     5.713 ns |   0.1497 ns |   0.2501 ns |     5.649 ns |  1.76x slower |   0.19x |      - |         - |          NA |
| Array_MoreLinq                          | Array      | 10    |    44.599 ns |   1.4621 ns |   4.1951 ns |    42.677 ns | 13.92x slower |   1.72x | 0.0573 |     120 B |          NA |
| Array_ForEachEx_Action                  | Array      | 10    |    28.329 ns |   0.5248 ns |   0.6445 ns |    28.353 ns |  8.72x slower |   0.95x | 0.0421 |      88 B |          NA |
| Array_ForEachEx_ValueAction             | Array      | 10    |     4.146 ns |   0.1630 ns |   0.4676 ns |     3.961 ns |  1.30x slower |   0.21x |      - |         - |          NA |
| Array_ForEachVectorEx                   | Array      | 10    |     4.024 ns |   0.1195 ns |   0.2863 ns |     3.931 ns |  1.26x slower |   0.15x |      - |         - |          NA |
| ArrayAsEnumerable_ForEachEx_Action      | Array      | 10    |    25.821 ns |   0.5460 ns |   1.3186 ns |    25.319 ns |  8.08x slower |   0.91x | 0.0421 |      88 B |          NA |
| ArrayAsEnumerable_ForEachEx_ValueAction | Array      | 10    |     9.195 ns |   0.2141 ns |   0.5332 ns |     8.987 ns |  2.89x slower |   0.30x |      - |         - |          NA |
| ArrayAsEnumerable_ForEachVectorEx       | Array      | 10    |     9.936 ns |   0.3677 ns |   1.0551 ns |     9.399 ns |  3.11x slower |   0.43x |      - |         - |          NA |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **Array_foreach**                           | **Array**      | **1000**  |   **407.077 ns** |   **8.1516 ns** |  **23.3884 ns** |   **401.663 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| Array_Sum                               | Array      | 1000  |   108.525 ns |   3.1662 ns |   9.2859 ns |   105.905 ns |  3.79x faster |   0.41x |      - |         - |          NA |
| Array_MoreLinq                          | Array      | 1000  | 1,893.639 ns |  37.7298 ns | 103.2846 ns | 1,874.169 ns |  4.68x slower |   0.31x | 0.0572 |     120 B |          NA |
| Array_ForEachEx_Action                  | Array      | 1000  | 1,572.148 ns |  45.4673 ns | 128.2413 ns | 1,564.961 ns |  3.88x slower |   0.39x | 0.0420 |      88 B |          NA |
| Array_ForEachEx_ValueAction             | Array      | 1000  |   429.038 ns |   9.3706 ns |  26.8861 ns |   422.231 ns |  1.06x slower |   0.09x |      - |         - |          NA |
| Array_ForEachVectorEx                   | Array      | 1000  |    68.678 ns |   2.7777 ns |   7.9696 ns |    64.780 ns |  5.99x faster |   0.65x |      - |         - |          NA |
| ArrayAsEnumerable_ForEachEx_Action      | Array      | 1000  | 1,386.267 ns |  25.9998 ns |  55.4076 ns | 1,360.837 ns |  3.43x slower |   0.22x | 0.0420 |      88 B |          NA |
| ArrayAsEnumerable_ForEachEx_ValueAction | Array      | 1000  | 1,574.277 ns |  26.7205 ns |  24.9943 ns | 1,583.422 ns |  3.83x slower |   0.23x |      - |         - |          NA |
| ArrayAsEnumerable_ForEachVectorEx       | Array      | 1000  | 1,600.861 ns |  31.1595 ns |  30.6028 ns | 1,610.637 ns |  3.90x slower |   0.20x |      - |         - |          NA |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **Enumerable_foreach**                      | **Enumerable** | **10**    |   **608.570 ns** |  **21.9777 ns** |  **63.4107 ns** |   **591.631 ns** |      **baseline** |        **** | **0.1678** |     **352 B** |            **** |
| Enumerable_Sum                          | Enumerable | 10    |   594.804 ns |  14.0667 ns |  38.7439 ns |   585.151 ns |  1.03x faster |   0.12x | 0.1678 |     352 B |  1.00x more |
| Enumerable_MoreLinq                     | Enumerable | 10    |   625.260 ns |  20.8870 ns |  59.5917 ns |   616.038 ns |  1.04x slower |   0.15x | 0.2098 |     440 B |  1.25x more |
| Enumerable_ForEachEx_Action             | Enumerable | 10    |   603.112 ns |  15.0955 ns |  42.5771 ns |   585.158 ns |  1.02x faster |   0.14x | 0.2098 |     440 B |  1.25x more |
| Enumerable_ForEachEx_ValueAction        | Enumerable | 10    |   560.779 ns |  11.1962 ns |  28.7001 ns |   549.943 ns |  1.10x faster |   0.14x | 0.1678 |     352 B |  1.00x more |
| Enumerable_ForEachVectorEx              | Enumerable | 10    |   589.110 ns |  17.5618 ns |  49.5334 ns |   584.774 ns |  1.05x faster |   0.16x | 0.1678 |     352 B |  1.00x more |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **Enumerable_foreach**                      | **Enumerable** | **1000**  | **6,397.874 ns** | **164.4824 ns** | **469.2775 ns** | **6,220.867 ns** |      **baseline** |        **** | **0.1678** |     **352 B** |            **** |
| Enumerable_Sum                          | Enumerable | 1000  | 6,721.222 ns |  94.5439 ns |  83.8107 ns | 6,720.968 ns |  1.08x slower |   0.07x | 0.1678 |     352 B |  1.00x more |
| Enumerable_MoreLinq                     | Enumerable | 1000  | 6,021.430 ns | 169.9852 ns | 484.9772 ns | 5,901.545 ns |  1.07x faster |   0.10x | 0.2060 |     440 B |  1.25x more |
| Enumerable_ForEachEx_Action             | Enumerable | 1000  | 6,704.162 ns | 151.5768 ns | 432.4571 ns | 6,578.377 ns |  1.05x slower |   0.11x | 0.2060 |     440 B |  1.25x more |
| Enumerable_ForEachEx_ValueAction        | Enumerable | 1000  | 5,920.227 ns | 212.0801 ns | 587.6729 ns | 5,741.037 ns |  1.09x faster |   0.12x | 0.1678 |     352 B |  1.00x more |
| Enumerable_ForEachVectorEx              | Enumerable | 1000  | 5,922.507 ns | 190.9350 ns | 547.8284 ns | 5,742.263 ns |  1.09x faster |   0.14x | 0.1678 |     352 B |  1.00x more |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **List_foreach**                            | **List**       | **10**    |     **8.190 ns** |   **0.1975 ns** |   **0.5570 ns** |     **7.957 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| List_foreach_AsSpan                     | List       | 10    |     4.100 ns |   0.1626 ns |   0.4665 ns |     3.899 ns |  2.02x faster |   0.25x |      - |         - |          NA |
| List_Sum                                | List       | 10    |     5.701 ns |   0.2139 ns |   0.5997 ns |     5.452 ns |  1.45x faster |   0.15x |      - |         - |          NA |
| List_ForEach                            | List       | 10    |    26.624 ns |   0.4846 ns |   1.0739 ns |    26.229 ns |  3.23x slower |   0.22x | 0.0421 |      88 B |          NA |
| List_MoreLinq                           | List       | 10    |    45.288 ns |   0.7932 ns |   0.9442 ns |    45.166 ns |  5.37x slower |   0.36x | 0.0612 |     128 B |          NA |
| List_ForEachEx_Action                   | List       | 10    |    26.341 ns |   0.5608 ns |   1.2542 ns |    25.959 ns |  3.20x slower |   0.28x | 0.0421 |      88 B |          NA |
| List_ForEachEx_ValueAction              | List       | 10    |     5.394 ns |   0.1646 ns |   0.4774 ns |     5.272 ns |  1.53x faster |   0.17x |      - |         - |          NA |
| List_ForEachVectorEx                    | List       | 10    |     4.474 ns |   0.1385 ns |   0.4039 ns |     4.346 ns |  1.85x faster |   0.21x |      - |         - |          NA |
| ListAsEnumerable_ForEachEx_Action       | List       | 10    |    26.807 ns |   0.5667 ns |   0.4733 ns |    26.754 ns |  3.18x slower |   0.26x | 0.0421 |      88 B |          NA |
| ListAsEnumerable_ForEachEx_ValueAction  | List       | 10    |    15.176 ns |   0.2007 ns |   0.1779 ns |    15.180 ns |  1.79x slower |   0.13x |      - |         - |          NA |
| ListAsEnumerable_ForEachVectorEx        | List       | 10    |    10.463 ns |   0.3992 ns |   1.1453 ns |     9.992 ns |  1.28x slower |   0.15x |      - |         - |          NA |
|                                         |            |       |              |             |             |              |               |         |        |           |             |
| **List_foreach**                            | **List**       | **1000**  |   **658.083 ns** |  **15.6968 ns** |  **44.7839 ns** |   **640.869 ns** |      **baseline** |        **** |      **-** |         **-** |          **NA** |
| List_foreach_AsSpan                     | List       | 1000  |   395.999 ns |   7.8876 ns |   9.0834 ns |   395.689 ns |  1.64x faster |   0.11x |      - |         - |          NA |
| List_Sum                                | List       | 1000  |    95.485 ns |   1.8862 ns |   3.3035 ns |    94.404 ns |  6.91x faster |   0.51x |      - |         - |          NA |
| List_ForEach                            | List       | 1000  | 1,436.259 ns |  21.8308 ns |  18.2297 ns | 1,433.540 ns |  2.18x slower |   0.15x | 0.0420 |      88 B |          NA |
| List_MoreLinq                           | List       | 1000  | 2,244.746 ns |  44.5635 ns |  66.7006 ns | 2,221.585 ns |  3.42x slower |   0.25x | 0.0610 |     128 B |          NA |
| List_ForEachEx_Action                   | List       | 1000  | 1,420.337 ns |  28.1394 ns |  64.0877 ns | 1,394.379 ns |  2.16x slower |   0.18x | 0.0420 |      88 B |          NA |
| List_ForEachEx_ValueAction              | List       | 1000  |   402.382 ns |   8.0132 ns |  18.4118 ns |   397.663 ns |  1.65x faster |   0.11x |      - |         - |          NA |
| List_ForEachVectorEx                    | List       | 1000  |    62.973 ns |   1.3694 ns |   4.0161 ns |    61.037 ns | 10.46x faster |   0.89x |      - |         - |          NA |
| ListAsEnumerable_ForEachEx_Action       | List       | 1000  | 1,260.932 ns |  20.6311 ns |  18.2890 ns | 1,257.326 ns |  1.92x slower |   0.14x | 0.0420 |      88 B |          NA |
| ListAsEnumerable_ForEachEx_ValueAction  | List       | 1000  | 1,569.519 ns |  23.8497 ns |  22.3090 ns | 1,574.694 ns |  2.40x slower |   0.16x |      - |         - |          NA |
| ListAsEnumerable_ForEachVectorEx        | List       | 1000  | 1,567.128 ns |  21.8629 ns |  20.4506 ns | 1,573.746 ns |  2.39x slower |   0.17x |      - |         - |          NA |
