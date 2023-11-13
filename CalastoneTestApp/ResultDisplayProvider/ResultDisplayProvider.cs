namespace CalastoneTestApp.ResultDisplayProvider;

public class ResultDisplayProvider : IResultDisplayProvider
{
    public void Display(IEnumerable<string> displayWords)
    {
        try
        {
            var final = string.Join("", displayWords);
            var displayValue = Regex.Replace(final, @"\s+", " ").Trim();

            Console.WriteLine(displayValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Results Display Provider: { ex.Message }");
            throw;
        }
    }
}
