namespace CalastoneTestAppTests;

public class MinLengthFilterTests
{
    [Fact]
    public void Filter_WhenGivenValidLength_ShouldReturnWordsWithGreaterLength()
    {
        // arrange
        const string minLength = "3";
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };
        var filter = new MinLengthFilter(); 

        // act
        var actual = filter.Filter(input, minLength);

        // assert
        var expected = new[] { "this", "", "the", "test", "input", "", "use" };
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Filter_WhenGivenInvalidLength_ShouldReturnUnchangedList()
    {
        // arrange
        const string minLength = "1";
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };
        var filter = new MinLengthFilter(); 

        // act
        var actual = filter.Filter(input, minLength);

        // assert
        var expected = input;
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Filter_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        const string minLength = "3";
        var input = Array.Empty<string>();
        var filter = new MinLengthFilter(); 

        // act
        var actual = () => filter.Filter(input, minLength);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}
