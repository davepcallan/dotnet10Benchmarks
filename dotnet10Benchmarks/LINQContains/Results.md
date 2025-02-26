```

BenchmarkDotNet v0.14.1-nightly.20250107.205, Windows 10 (10.0.17763.6893/1809/October2018Update/Redstone5) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK 10.0.100-preview.3.25126.13
  [Host]    : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.12516), X64 RyuJIT AVX2
  .NET 9.0  : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method                 | Runtime   | Mean         | Error      | StdDev     | Median       | Ratio    | Gen1   | Allocated | 
|----------------------- |---------- |-------------:|-----------:|-----------:|-------------:|---------:|-------:|----------:|
| AppendContains         | .NET 10.0 |     90.32 ns |   0.543 ns |   0.508 ns |     90.23 ns |     -98% |      - |      56 B | 
| AppendContains         | .NET 9.0  |  3,817.99 ns |  61.553 ns |  57.577 ns |  3,811.51 ns | baseline |      - |      88 B | 
|                        |           |              |            |            |              |          |        |           | 
| ConcatContains         | .NET 10.0 |     93.28 ns |   0.404 ns |   0.358 ns |     93.30 ns |     -98% |      - |      56 B | 
| ConcatContains         | .NET 9.0  |  3,949.19 ns |  78.348 ns | 170.323 ns |  3,914.35 ns | baseline |      - |      88 B | 
|                        |           |              |            |            |              |          |        |           | 
| DefaultIfEmptyContains | .NET 10.0 |     75.12 ns |   1.080 ns |   1.010 ns |     75.13 ns |     -21% |      - |         - | 
| DefaultIfEmptyContains | .NET 9.0  |     94.67 ns |   0.449 ns |   0.420 ns |     94.79 ns | baseline |      - |         - | 
|                        |           |              |            |            |              |          |        |           | 
| OrderByContains        | .NET 10.0 |     86.57 ns |   0.790 ns |   0.739 ns |     86.49 ns |   -99.4% |      - |      88 B | 
| OrderByContains        | .NET 9.0  | 14,936.51 ns | 124.134 ns | 116.115 ns | 14,929.79 ns | baseline | 0.0153 |   12280 B | 
|                        |           |              |            |            |              |          |        |           | 
| ReverseContains        | .NET 10.0 |     84.46 ns |   0.647 ns |   0.574 ns |     84.47 ns |     -61% |      - |      48 B | 
| ReverseContains        | .NET 9.0  |    219.60 ns |   4.423 ns |  12.402 ns |    215.68 ns | baseline |      - |    4072 B | 
|                        |           |              |            |            |              |          |        |           | 
| WhereSelectContains    | .NET 10.0 |    382.09 ns |   5.455 ns |   4.835 ns |    380.71 ns |     -84% |      - |     104 B | 
| WhereSelectContains    | .NET 9.0  |  2,401.40 ns |  16.886 ns |  14.969 ns |  2,404.14 ns | baseline |      - |     104 B | 
|                        |           |              |            |            |              |          |        |           | 
| UnionContains          | .NET 10.0 |     93.64 ns |   0.823 ns |   0.730 ns |     93.64 ns |   -99.5% |      - |      72 B | 
| UnionContains          | .NET 9.0  | 17,419.37 ns | 342.210 ns | 501.607 ns | 17,386.03 ns | baseline | 0.3662 |   58664 B |