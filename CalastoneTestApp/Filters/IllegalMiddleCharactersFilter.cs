namespace CalastoneTestApp.Filters;

public class IllegalMiddleCharactersFilter : FilterBase, IFilter
{
    public override FilterEnum FilterType => FilterEnum.IllegalMiddleCharactersFilter;

    public override IEnumerable<string> Filter(IEnumerable<string> words, string illegalChars)
    {
        if (words != null && !words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        var illegalCharsArray = illegalChars.Split(',').Select(ic => ic.Trim().ToCharArray().First());

        var updatedWords = words?.Select(originalWord =>
        {
            var sanitizedWord = Regex.Replace(originalWord, "[,!`?'();:. ]", "");

            if (sanitizedWord.Length <= 2)
                return originalWord;

            var offset = sanitizedWord.Length % 2 == 0 ? 1 : 0;
            var middle = sanitizedWord.Substring(sanitizedWord.Length / 2 - offset, offset + 1).ToLowerInvariant();

            var shouldRemoveWord = middle.ToArray().Intersect(illegalCharsArray).Any();

            return shouldRemoveWord ? originalWord.Replace(sanitizedWord, "") : originalWord;
        });

        return updatedWords;
    }

}
