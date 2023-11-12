namespace CalastoneTestApp;

public static class Filters
{
    public static IEnumerable<string> FilterWordsContainingIlegalMiddleChars(this IEnumerable<string> words, char[] ilegalChars)
    {
        if (!words.Any()) throw new InvalidOperationException("Input words array contains no elements");
        if (ilegalChars is null) throw new ArgumentNullException(nameof(ilegalChars));

        return words.Where(w =>
        {
            if (w.Length <= 2) return true;

            var offset = w.Length % 2 == 0 ? 1 : 0;
            var middle = w.Substring(w.Length / 2 - offset, offset + 1);

            return !middle.ToArray().Intersect(ilegalChars).Any();
        });
    }

    public static IEnumerable<string> FilterWordsContainingIlegalChar(this IEnumerable<string> words, char ilegalChar)
    {
        if (!words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        return words.Where(w => !w.Contains(ilegalChar));
    }

    public static IEnumerable<string> FilterWordsLessThanMinLength(this IEnumerable<string> words, int minLength)
    {
        if (!words.Any()) throw new InvalidOperationException("Input words array contains no elements");

        return words.Where(w => w.Length >= minLength);
    }
}
