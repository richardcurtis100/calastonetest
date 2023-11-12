namespace CalastoneTestApp;

public class ResultDisplayProvider : IResultDisplayProvider
{
    public void Display(IEnumerable<string> displayWords)
    {
        foreach (var word in displayWords)
        {
            Console.WriteLine(word);
        }
    }
}
