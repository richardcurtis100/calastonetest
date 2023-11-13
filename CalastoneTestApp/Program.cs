var serviceProvider = new ServiceCollection()
    .AddScoped<IFileProcessor, FileProcessor>()
    .AddScoped<IFilterWordsProvider, FilterWordsProvider>()
    .AddScoped<IFileContentProvider, FileContentProvider>()
    .AddScoped<IResultDisplayProvider, ResultDisplayProvider>()
    .AddScoped<IFilter, IllegalCharacterFilter>()
    .AddScoped<IFilter, MinLengthFilter>()
    .AddScoped<IFilter, IllegalMiddleCharactersFilter>()
    .BuildServiceProvider();

try
{
    var inputs = new List<string> { "CalastoneText.txt" };

    inputs.ForEach(i =>
    {
        var fileProcessor = serviceProvider.GetService<IFileProcessor>();
        var finalWords = fileProcessor?.Process(i);

        if (finalWords == null) return;
        var resultDisplayProvider = serviceProvider.GetService<IResultDisplayProvider>();
        resultDisplayProvider?.Display(finalWords);
    });
}
catch (Exception ex)
{
    // logging here
}

Console.ReadKey();