namespace CalastoneTestApp.FilterWordsProvider;

public interface IFilterWordsProvider
{
    IEnumerable<string> Generate(string input);
}