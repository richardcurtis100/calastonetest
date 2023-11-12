namespace CalastoneTestApp.FilterWordsProvider
{
    public class FilterWordsProvider : IFilterWordsProvider
    {
        public IEnumerable<string> Generate(string input)
        {
            input = input.Replace("\r\n", " ");
            return Regex.Split(input, @"(?<=[,!`?'();:. ])"); // Regex filter delimiters should go to config
        }
    }
}
