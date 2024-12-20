namespace EtlCsv.Extractors;

public interface IExtractor<T>
{
    public IEnumerable<T> Extract();
    public bool HasMoreData();
}