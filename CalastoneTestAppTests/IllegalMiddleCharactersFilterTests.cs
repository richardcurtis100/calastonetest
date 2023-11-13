namespace CalastoneTestAppTests;

public class IllegalMiddleCharactersFilterTests
{
    [Fact]
    public void Filter_WhenGivenValidChars_ShouldReturnWordsWithoutIllegalChars()
    {
        // arrange
        const string illegalChars = "a, e, i, o, u";
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };
        var filter = new IllegalMiddleCharactersFilter();

        // act
        var actual = filter.Filter(input, illegalChars);

        // assert
        var expected = new[] { "", "is", "the", "", "input", "to", "use" };
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Filter_WhenGivenInvalidChars_ShouldReturnUnchangedList()
    {
        // arrange
        const string illegalChars = "z";
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };
        var filter = new IllegalMiddleCharactersFilter();

        // act
        var actual = filter.Filter(input, illegalChars);

        // assert
        var expected = input;
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Filter_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        // arrange
        const string illegalChars = "a, e, i, o, u";
        var input = Array.Empty<string>();
        var filter = new IllegalMiddleCharactersFilter();

        // act
        var actual = () => filter.Filter(input, illegalChars);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}
