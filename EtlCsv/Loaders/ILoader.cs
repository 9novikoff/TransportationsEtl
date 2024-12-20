namespace EtlCsv.Loaders;

public interface ILoader<T>
{
    public void Load(IEnumerable<T> data);
}