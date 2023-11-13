namespace CalastoneTestApp.FileContentProvider;

public class FileContentProvider : IFileContentProvider
{
    public string ReadFile(string filePath)
    {
        var output = "";

        try
        {
            using var sr = new StreamReader(filePath);
            output = sr.ReadToEnd();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            throw;
        }

        return output;
    }
}
