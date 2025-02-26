```

BenchmarkDotNet v0.14.1-nightly.20250107.205, Windows 10 (10.0.17763.6893/1809/October2018Update/Redstone5) (Hyper-V)
AMD EPYC 7763 2.44GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK 10.0.100-preview.3.25126.13
  [Host]    : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  .NET 10.0 : .NET 10.0.0 (10.0.25.12516), X64 RyuJIT AVX2
  .NET 9.0  : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method                    | Runtime   | Length | Mean        | Error     | StdDev    | Ratio    | Allocated | 
|-------------------------- |---------- |------- |------------:|----------:|----------:|---------:|----------:|
| **WithRandom**                | **.NET 10.0** | **4**      |    **25.27 ns** |  **0.217 ns** |  **0.203 ns** |     **-12%** |      **32 B** | 
| WithRandom                | .NET 9.0  | 4      |    28.75 ns |  0.381 ns |  0.357 ns | baseline |      32 B | 
|                           |           |        |             |           |           |          |           | 
| WithRandomNumberGenerator | .NET 10.0 | 4      |    81.24 ns |  0.844 ns |  0.749 ns |     -67% |      32 B | 
| WithRandomNumberGenerator | .NET 9.0  | 4      |   243.93 ns |  1.691 ns |  1.412 ns | baseline |      32 B | 
|                           |           |        |             |           |           |          |           | 
| **WithRandom**                | **.NET 10.0** | **40**     |   **108.59 ns** |  **1.087 ns** |  **1.017 ns** |     **-45%** |     **104 B** | 
| WithRandom                | .NET 9.0  | 40     |   199.17 ns |  1.061 ns |  0.992 ns | baseline |     104 B | 
|                           |           |        |             |           |           |          |           | 
| WithRandomNumberGenerator | .NET 10.0 | 40     |   293.02 ns |  1.592 ns |  1.330 ns |     -87% |     104 B | 
| WithRandomNumberGenerator | .NET 9.0  | 40     | 2,343.79 ns | 23.530 ns | 20.859 ns | baseline |     104 B | 