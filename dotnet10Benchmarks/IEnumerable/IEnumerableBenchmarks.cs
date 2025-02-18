using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

[Config(typeof(Config))]
[MemoryDiagnoser]
[HideColumns(Column.Job, Column.RatioSD, Column.Gen0, Column.AllocRatio)]
[ReturnValueValidator(true)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net90)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net10_0)]
public class IEnumerableBenchmarks
{
    static readonly int[] s_ro_array = new int[1000];
    private readonly IEnumerable<int> e = s_ro_array;

    [Benchmark(Baseline = true)]
    public int ForeachStaticReadonlyArray()
    {
        int sum = 0;
        foreach (int i in s_ro_array) sum += i;
        return sum;
    }

    [Benchmark]
    public int ForeachStaticReadonlyArrayViaInterface()
    {
        int sum = 0;
        foreach (int i in e) sum += i; 
        return sum;
    }

    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle =
                SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}