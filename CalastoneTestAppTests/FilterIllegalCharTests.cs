using CalastoneTestApp.Filters;

namespace CalastoneTestAppTests;

public class FilterIllegalCharTests
{
    [Fact]
    public void FilterWordsContainingIllegalChar_WhenGivenValidChar_ShouldReturnWordsWithoutIllegalChar()
    {
        // arrange
        var illegalChar = 'e';
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIlegalChar(illegalChar);

        // assert
        var expected = new [] { "this", "is", "", "", "input", "to", "" };
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FilterWordsContainingIllegalChar_WhenGivenInvalidChar_ShouldReturnUnchangedList()
    {
        // arrange
        var illegalChar = 'z';
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIlegalChar(illegalChar);

        // assert
        var expected = input;
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FilterWordsContainingIllegalChar_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        var illegalChar = 'e';
        var input = Array.Empty<string>();

        var actual = () => input.FilterWordsContainingIlegalChar(illegalChar);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}