using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using System.Security.Cryptography;

[Config(typeof(Config))]
[MemoryDiagnoser]
[HideColumns(Column.Job, Column.RatioSD, Column.Gen0, Column.AllocRatio)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net90, baseline:true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net10_0)]
public class RandomBenchmarks
{
    private const string Base58 = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

    [Params(4, 40)]
    public int Length { get; set; }

    [Benchmark]
    public char[] WithRandom() => Random.Shared.GetItems<char>(Base58, Length);

    [Benchmark]
    public char[] WithRandomNumberGenerator() => RandomNumberGenerator.GetItems<char>(Base58, Length);

    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle =
                SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}