using EtlCsv.Extractors;
using EtlCsv.Loaders;

namespace EtlCsv;

public class Etl<T>
{
    private readonly IExtractor<T> _extractor;
    private readonly ILoader<T> _loader;

    public Etl(IExtractor<T> extractor, ILoader<T> loader)
    {
        _extractor = extractor;
        _loader = loader;
    }

    public void Run()
    {
        while (_extractor.HasMoreData())
        {
            var data = _extractor.Extract();
            _loader.Load(data);
        }
    }
}