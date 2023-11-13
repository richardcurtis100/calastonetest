namespace CalastoneTestApp.FileProcessor;

public interface IFileProcessor
{
    IEnumerable<string> Process(string filePath);
}