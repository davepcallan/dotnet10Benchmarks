using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

[Config(typeof(Config))]
[MemoryDiagnoser]
[HideColumns(Column.Job, Column.RatioSD, Column.Gen0, Column.AllocRatio)]
[SimpleJob(RuntimeMoniker.Net90,baseline:true)]
[SimpleJob(RuntimeMoniker.Net10_0)]
public class ArrayIterationBenchmarks
{
    static readonly int[] s_ro_array = new int[1000];

    [Benchmark]
    public int ForeachStaticReadonlyArray()
    {
        int sum = 0;
        foreach (int i in s_ro_array) sum += i;
        return sum;
    }

    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}