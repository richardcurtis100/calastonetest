namespace CalastoneTestAppTests;

public class FileProcessorIntegrationTests
{
    [Fact]
    public void Process_WhenGivenValidInputFile_ShouldReturnCorrectlyFilteredWordList()
    {
        // this is a very rough test put in simply for best design time testing purposes
        // with more time, this test could be used to check the final output in more detail


        // arrange
        var fileContentProvider = new FileContentProvider();
        var filterWordProvider = new FilterWordsProvider();
        var illegalCharacterFilter = new IllegalCharacterFilter();
        var illegalMiddleCharactersFilter = new IllegalMiddleCharactersFilter();
        var minLengthFilter = new MinLengthFilter();
        var fileProcessor = new FileProcessor(fileContentProvider, filterWordProvider, 
            new List<IFilter> { illegalCharacterFilter, illegalMiddleCharactersFilter, minLengthFilter });

        // act
        var actual = fileProcessor.Process("CalastoneText.txt");
        
        // assert
        var expected = 515;
        actual.Count().Should().Be(expected);
    }
}
