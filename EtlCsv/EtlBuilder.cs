using EtlCsv.Extractors;
using EtlCsv.Loaders;

namespace EtlCsv;

public class EtlBuilder<T>
{
    private IExtractor<T> _extractor;
    private ILoader<T> _loader;

    public EtlBuilder<T> WithExtractor(IExtractor<T> extractor)
    {
        _extractor = extractor;
        return this;
    }

    public EtlBuilder<T> WithLoader(ILoader<T> loader)
    {
        _loader = loader;
        return this;
    }

    public Etl<T> Build()
    {
        if (_extractor == null || _loader == null)
        {
            throw new InvalidOperationException("Extractor and Loader must be set");
        }

        return new Etl<T>(_extractor, _loader);
    }
}