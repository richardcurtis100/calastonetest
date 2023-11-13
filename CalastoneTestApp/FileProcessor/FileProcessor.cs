namespace CalastoneTestApp.FileProcessor;

public class FileProcessor : IFileProcessor
{
    private readonly IFileContentProvider _fileContentProvider;
    private readonly IFilterWordsProvider _filterWordsProvider;
    private readonly IEnumerable<IFilter> _filters;
    private readonly Dictionary<FilterEnum, string> _filterConfig;

    public FileProcessor(IFileContentProvider fileContentProvider, IFilterWordsProvider filterWordsProvider, IEnumerable<IFilter> filters)
    {
        _fileContentProvider = fileContentProvider ?? throw new ArgumentNullException(nameof(fileContentProvider));
        _filterWordsProvider = filterWordsProvider ?? throw new ArgumentNullException(nameof(filterWordsProvider));
        _filters = filters ?? throw new ArgumentNullException(nameof(filters));

        // this is in place of proper configuration
        _filterConfig = new Dictionary<FilterEnum, string>
        {
            { FilterEnum.IllegalCharacterFilter, "t" },
            { FilterEnum.MinLengthFilter, "3" },
            { FilterEnum.IllegalMiddleCharactersFilter, "a, e, i, o, u" },
        };
    }

    public IEnumerable<string> Process(string filePath)
    {
        try
        {
            var input = _fileContentProvider.ReadFile(filePath);
            var parts = _filterWordsProvider.Generate(input);

            return _filters.Aggregate(parts, (words, filter)
                => filter.Filter(words, _filterConfig[filter.FilterType]));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in File Processor: { ex.Message }");
            throw;
        }
    }
}
