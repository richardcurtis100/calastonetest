namespace CalastoneTestApp.FilterWordsProvider;

public class FilterWordsProvider : IFilterWordsProvider
{
    public IEnumerable<string> Generate(string input)
    {
        try
        {
            input = input.Replace("\r\n", " ");
            return Regex.Split(input, @"(?<=[,!`?'();:. ])"); // Regex filter delimiters should go to config
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Filter Words Provider: { ex.Message }");
            throw;
        }
    }
}
