namespace CalastoneTestApp.ResultDisplayProvider;

public class ResultDisplayProvider : IResultDisplayProvider
{
    public void Display(IEnumerable<string> displayWords)
    {
        var final = string.Join("", displayWords);
        var displayValue = Regex.Replace(final, @"\s+", " ").Trim();

        Console.WriteLine(displayValue);
    }
}
