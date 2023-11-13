namespace CalastoneTestApp.Filters;

public abstract class FilterBase
{
    protected static readonly char[] DelimiterChars = { ',', '!', '`', '?', '\'', '(', ')', ' ' };
    
    public abstract FilterEnum FilterType { get; } 
    
    public abstract IEnumerable<string> Filter(IEnumerable<string> words, string param);
}