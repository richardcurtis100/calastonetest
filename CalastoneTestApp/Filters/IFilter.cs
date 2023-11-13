namespace CalastoneTestApp.Filters;

public interface IFilter
{
    FilterEnum FilterType { get; } 
    IEnumerable<string> Filter(IEnumerable<string> words, string param);
}