namespace CalastoneTestApp.Filters;

public class IllegalCharacterFilter : FilterBase, IFilter
{
    public override FilterEnum FilterType => FilterEnum.IllegalCharacterFilter;

    public override IEnumerable<string> Filter(IEnumerable<string> words, string illegalChar)
    {
        if (words != null && !words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        var updatedWords = words?.Select(originalWord =>
        {
            var actualWord = Regex.Replace(originalWord,"[,!`?'();:. ]", "");

            if (actualWord.Length == 0)
                return originalWord;

            return actualWord.ToLowerInvariant().Contains(illegalChar) ? originalWord.Replace(actualWord, "") : originalWord;
        });

        return updatedWords;
    }
}