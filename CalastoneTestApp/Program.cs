var serviceProvider = new ServiceCollection()
    .AddScoped<IFileProcessor, FileProcessor>()
    .AddScoped<IFilterWordsProvider, FilterWordsProvider>()
    .AddScoped<IFileContentProvider, FileContentProvider>()
    .AddScoped<IResultDisplayProvider, ResultDisplayProvider>()
    .BuildServiceProvider();

try
{
    var fileProcessor = serviceProvider.GetService<IFileProcessor>();
    var finalWords = fileProcessor?.Process();

    if (finalWords != null)
    {
        var resultDisplayProvider = serviceProvider.GetService<IResultDisplayProvider>();
        resultDisplayProvider?.Display(finalWords);
    }
}
catch (Exception ex)
{
    // logging here
}

Console.ReadKey();