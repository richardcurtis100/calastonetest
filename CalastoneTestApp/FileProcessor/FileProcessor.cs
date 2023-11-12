namespace CalastoneTestApp.FileProcessor;

public class FileProcessor : IFileProcessor
{
    private readonly IFileContentProvider _fileContentProvider;
    private readonly IFilterWordsProvider _filterWordsProvider;

    public FileProcessor(IFileContentProvider fileContentProvider, IFilterWordsProvider filterWordsProvider)
    {
        _fileContentProvider = fileContentProvider ?? throw new ArgumentNullException(nameof(fileContentProvider));
        _filterWordsProvider = filterWordsProvider ?? throw new ArgumentNullException(nameof(filterWordsProvider));
    }

    public IEnumerable<string> Process()
    {
        var input = _fileContentProvider.ReadFile("CalastoneText.txt"); // This should go to config
        var parts = _filterWordsProvider.Generate(input);

        var result = parts.FilterWordsContainingIllegalMiddleChars(new[] { 'a', 'e', 'i', 'o', 'u' }) // This should go to config
            .FilterWordsContainingIlegalChar('t') // This should go to config
            .FilterWordsLessThanMinLength(3); // This should go to config

        return result;
    }
}
