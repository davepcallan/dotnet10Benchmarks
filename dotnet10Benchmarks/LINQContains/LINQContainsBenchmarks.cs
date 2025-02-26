using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

[Config(typeof(Config))]
[MemoryDiagnoser]
[HideColumns(Column.Job, Column.RatioSD, Column.Gen0, Column.AllocRatio)]
[ReturnValueValidator(true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net90, baseline:true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net10_0)]
public class LINQContainsBenchmarks
{
    private int[] _source = Enumerable.Range(0, 1000).ToArray();

    [Benchmark]
    public bool AppendContains() => _source.Append(100).Contains(999);

    [Benchmark]
    public bool ConcatContains() => _source.Concat(_source).Contains(999);

    [Benchmark]
    public bool DefaultIfEmptyContains() => _source.DefaultIfEmpty(42).Contains(999);

    [Benchmark]
    public bool OrderByContains() => _source.OrderBy(x => x).Contains(999);

    [Benchmark]
    public bool ReverseContains() => _source.Reverse().Contains(999);

    [Benchmark]
    public bool WhereSelectContains() => _source.Where(x => true).Select(x => x).Contains(999);

    [Benchmark]
    public bool UnionContains() => _source.Union(_source).Contains(999);

    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle =
                SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}