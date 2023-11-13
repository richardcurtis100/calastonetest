namespace CalastoneTestAppTests;

public class IllegalCharacterFilterTests
{
    [Fact]
    public void Filter_WhenGivenValidChar_ShouldReturnWordsWithoutIllegalChar()
    {
        // arrange
        const string illegalChar = "e";
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };
        var filter = new IllegalCharacterFilter();

        // act
        var actual = filter.Filter(input, illegalChar);

        // assert
        var expected = new [] { "this", "is", "", "", "input", "to", "" };
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Filter_WhenGivenInvalidChar_ShouldReturnUnchangedList()
    {
        // arrange
        const string illegalChar = "z";
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };
        var filter = new IllegalCharacterFilter();
    
        // act
        var actual = filter.Filter(input, illegalChar);

        // assert
        var expected = input;
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Filter_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        const string illegalChar = "e";
        var input = Array.Empty<string>();
        var filter = new IllegalCharacterFilter();

        var actual = () => filter.Filter(input, illegalChar);
    
        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}