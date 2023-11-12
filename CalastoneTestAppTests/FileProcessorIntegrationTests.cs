namespace CalastoneTestAppTests;

public class FileProcessorIntegrationTests
{
    [Fact]
    public void Process_WhenGivenValidInputFile_ShouldReturnCorrectlyFilteredWordList()
    {
        // arrange
        var fileContentProvider = new FileContentProvider();
        var inputSanitizer = new InputSanitizer();
        var fileProcessor = new FileProcessor(fileContentProvider, inputSanitizer);

        // act
        var actual = fileProcessor.Process();

        // assert
        var expected = 79;
        actual.Should().NotBeNull();
        actual.Count().Should().Be(expected);
    }
}
