namespace CalastoneTestApp.Filters;

public class MinLengthFilter : FilterBase, IFilter
{
    public override FilterEnum FilterType => FilterEnum.MinLengthFilter;

    public override IEnumerable<string> Filter(IEnumerable<string> words, string minLength)
    {
        if (words != null && !words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        return words?.Select(originalWord =>
        {
            var actualWord = Regex.Replace(originalWord, "[,!`?'();:. ]", "");

            if (actualWord.Length == 0)
                return originalWord;

            if (actualWord.Length == 1 && DelimiterChars.Contains(originalWord.ToCharArray().First()))
                return originalWord;

            return actualWord.Length < Convert.ToInt32(minLength) ? originalWord.Replace(actualWord, "") : originalWord;
        });
    }
}