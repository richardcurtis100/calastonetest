using CalastoneTestApp.Filters;

namespace CalastoneTestAppTests;

public class FilterLessThanMinLengthTests
{
    [Fact]
    public void FilterWordsLessThanMinLength_WhenGivenValidLength_ShouldReturnWordsWithGreaterLength()
    {
        // arrange
        const int minLength = 3;
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsLessThanMinLength(minLength);

        // assert
        var expected = new[] { "this", "", "the", "test", "input", "", "use" };
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FilterWordsLessThanMinLength_WhenGivenInvalidChar_ShouldReturnUnchangedList()
    {
        // arrange
        const int minLength = 1;
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsLessThanMinLength(minLength);

        // assert
        var expected = input;
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FilterWordsLessThanMinLength_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        const int minLength = 3;
        var input = Array.Empty<string>();

        var actual = () => input.FilterWordsLessThanMinLength(minLength);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}
