namespace CalastoneTestApp;

public class FileProcessor : IFileProcessor
{
    private readonly IFileContentProvider _fileContentProvider;
    private readonly IInputSanitizer _inputSanitizer;

    public FileProcessor(IFileContentProvider fileContentProvider, IInputSanitizer inputSanitizer)
    {
        _fileContentProvider = fileContentProvider ?? throw new ArgumentNullException(nameof(fileContentProvider));
        _inputSanitizer = inputSanitizer ?? throw new ArgumentNullException(nameof(inputSanitizer));
    }

    public IEnumerable<string> Process()
    {
        var input = _fileContentProvider.ReadFile("CalastoneText.txt");
        input = _inputSanitizer.Sanitize(input);
        var words = input.Split(' ');

        var finalWords = words.FilterWordsContainingIlegalMiddleChars(new[] { 'a', 'e', 'i', 'o', 'u' })
            .FilterWordsContainingIlegalChar('t')
            .FilterWordsLessThanMinLength(3);

        return finalWords;
    }
}
