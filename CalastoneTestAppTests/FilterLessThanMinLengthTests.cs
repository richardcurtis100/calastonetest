namespace CalastoneTestAppTests;

public class FilterLessThanMinLengthTests
{
    [Fact]
    public void FilterWordsLessThanMinLength_WhenGivenValidLength_ShouldReturnWordsWithGreaterLength()
    {
        // arrange
        var minLength = 3;
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsLessThanMinLength(minLength);

        // assert
        var expected = 5;
        actual.Should().NotBeNull();
        actual.Count().Should().Be(expected);
    }

    [Fact]
    public void FilterWordsLessThanMinLength_WhenGivenInvalidChar_ShouldReturnUnchangedList()
    {
        // arrange
        var minLength = 1;
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsLessThanMinLength(minLength);

        // assert
        var expected = input.Length;
        actual.Should().NotBeNull();
        actual.Count().Should().Be(expected);
    }

    [Fact]
    public void FilterWordsLessThanMinLength_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        var minLength = 3;
        var input = Array.Empty<string>();

        var actual = () => input.FilterWordsLessThanMinLength(minLength);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}
