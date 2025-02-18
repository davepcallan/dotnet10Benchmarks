using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using System.Collections.Frozen;

[Config(typeof(Config))]
[MemoryDiagnoser]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio, Column.Gen0, Column.Gen1)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.SlowestToFastest)]
public class FrozenDictionaryIntBenchmarks
{
    private KeyValuePair<int, int>[] _items = null!;
    private int[] _keys = null!;
    private FrozenDictionary<int, int> _frozenDictionary = null!;

    [Params(100)]
    public int Items;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _items = Enumerable
            .Range(0, Items)
            .Select(i => new KeyValuePair<int, int>(i, 0))
            .ToArray();

        _keys = _items.Select(k => k.Key).ToArray();
        _frozenDictionary = FrozenDictionary.ToFrozenDictionary(_items);
    }

    [BenchmarkCategory("Construct"), Benchmark]
    public FrozenDictionary<int, int> ConstructFrozenDictionary() =>
        FrozenDictionary.ToFrozenDictionary(_items);

    [BenchmarkCategory("TryGetValue_Found"), Benchmark]
    public bool FrozenDictionary_TryGetValue_Found()
    {
        bool allFound = true;

        foreach (int key in _keys)
        {
            int value;
            allFound &= _frozenDictionary.TryGetValue(key, out value);
        }

        return allFound;
    }

    private class Config : ManualConfig
    {
        public Config()
        {
            AddJob(Job.Default.WithId(".NET 9").WithRuntime(CoreRuntime.Core90).AsBaseline());
            AddJob(Job.Default.WithId(".NET 10").WithRuntime(CoreRuntime.Core10_0)); // 10.0.0-preview.2.25117.1 +

            SummaryStyle =
                SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}