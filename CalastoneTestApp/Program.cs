var serviceProvider = new ServiceCollection()
    .AddScoped<IFileProcessor, FileProcessor>()
    .AddScoped<IInputSanitizer, InputSanitizer>()
    .AddScoped<IFileContentProvider, FileContentProvider>()
    .AddScoped<IResultDisplayProvider, ResultDisplayProvider>()
    .BuildServiceProvider();

var fileProcessor = serviceProvider.GetService<IFileProcessor>();
var result = fileProcessor?.Process();

if (result != null)
{
    var resultDisplayProvider = serviceProvider.GetService<IResultDisplayProvider>();
    resultDisplayProvider?.Display(result);
}