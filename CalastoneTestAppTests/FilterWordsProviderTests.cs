namespace CalastoneTestAppTests;

public class FilterWordsProviderTests
{
    [Fact]
    public void Generate_WhenProvidedValidString_ShouldReturnCorrectlySeparatedStringList()
    {
        // arrange
        var filterWordsProvider = new FilterWordsProvider();
        
        // act
        const string testInput = "This; is the 'test' input to use.";
        var actual = filterWordsProvider.Generate(testInput);

        // assert
        var expected = new[] { "This;", " ", "is ", "the ", "'", "test'", " ", "input ", "to ", "use.", "" };
        actual.Should().BeEquivalentTo(expected);
    }
}