```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
11th Gen Intel Core i5-1135G7 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.202
  [Host]     : .NET Core 3.1.30 (CoreCLR 4.700.22.47601, CoreFX 4.700.22.47602), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET Core 3.1.30 (CoreCLR 4.700.22.47601, CoreFX 4.700.22.47602), X64 RyuJIT AVX2


```
| Method             | Size | Mean      | Error     | StdDev    | Median    | Q1        | Q3        | Allocated |
|------------------- |----- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| GetDataWithWhile   | ?    | 0.7474 ms | 0.0148 ms | 0.0427 ms | 0.7389 ms | 0.7210 ms | 0.7779 ms |     360 B |
| GetDataWithForeach | ?    | 0.7186 ms | 0.0140 ms | 0.0167 ms | 0.7204 ms | 0.7027 ms | 0.7294 ms |     359 B |
