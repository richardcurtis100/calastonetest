namespace CalastoneTestAppTests;

public class FileProcessorIntegrationTests
{
    [Fact]
    public void Process_WhenGivenValidInputFile_ShouldReturnCorrectlyFilteredWordList()
    {
        // this is a very rough test put in simply for best design time testing purposes


        // arrange
        var fileContentProvider = new FileContentProvider();
        var filterWordProvider = new FilterWordsProvider();
        var fileProcessor = new FileProcessor(fileContentProvider, filterWordProvider);

        // act
        var actual = fileProcessor.Process();

        // assert
        var expected = 515;
        actual.Count().Should().Be(expected);
    }
}
