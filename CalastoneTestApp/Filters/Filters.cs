namespace CalastoneTestApp.Filters;

public static partial class Filters
{
    private static readonly char[] DelimiterChars = { ',', '!', '`', '?', '\'', '(', ')', ' ' };

    [GeneratedRegex("[,!`?'();:. ]")]
    private static partial Regex CalastoneRegex();


    public static IEnumerable<string> FilterWordsContainingIllegalMiddleChars(this IEnumerable<string> words, char[] illegalChars)
    {
        if (words != null && !words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        var updatedWords = words?.Select(originalWord =>
        {
            var sanitizedWord = CalastoneRegex().Replace(originalWord, "");

            if (sanitizedWord.Length <= 2)
                return originalWord;

            var offset = sanitizedWord.Length % 2 == 0 ? 1 : 0;
            var middle = sanitizedWord.Substring(sanitizedWord.Length / 2 - offset, offset + 1).ToLowerInvariant();

            var shouldRemove = middle.ToArray().Intersect(illegalChars).Any();

            return shouldRemove ? originalWord.Replace(sanitizedWord, "") : originalWord;
        });

        return updatedWords;
    }

    public static IEnumerable<string> FilterWordsContainingIlegalChar(this IEnumerable<string> words, char ilegalChar)
    {
        if (words != null && !words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        var updatedWords = words?.Select(originalWord =>
        {
            var actualWord = CalastoneRegex().Replace(originalWord, "");

            if (actualWord.Length == 0)
                return originalWord;

            return actualWord.ToLowerInvariant().Contains(ilegalChar) ? originalWord.Replace(actualWord, "") : originalWord;
        });

        return updatedWords;
    }

    public static IEnumerable<string> FilterWordsLessThanMinLength(this IEnumerable<string> words, int minLength)
    {
        if (words != null && !words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        var updatedWords = words?.Select(originalWord =>
        {
            var testWord = CalastoneRegex().Replace(originalWord, "");

            if (testWord.Length == 0)
                return originalWord;

            if (testWord.Length == 1 && DelimiterChars.Contains(originalWord.ToCharArray().First()))
                return originalWord;

            return testWord.Length < minLength ? originalWord.Replace(testWord, "") : originalWord;
        });

        return updatedWords;
    }
}
