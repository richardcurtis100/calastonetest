using CalastoneTestApp.Filters;

namespace CalastoneTestAppTests;

public class FilterIllegalMiddleCharsTests
{
    [Fact]
    public void FilterWordsContainingIllegalMiddleChars_WhenGivenValidChars_ShouldReturnWordsWithoutIllegalChars()
    {
        // arrange
        var ilegalChars = new[] { 'a', 'e', 'i', 'o', 'u' };
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIllegalMiddleChars(ilegalChars);

        // assert
        var expected = new[] { "", "is", "the", "", "input", "to", "use" };
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FilterWordsContainingIllegalMiddleChars_WhenGivenInvalidChars_ShouldReturnUnchangedList()
    {
        // arrange
        var illegalChars = new[] { 'z' };
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIllegalMiddleChars(illegalChars);

        // assert
        var expected = input;
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FilterWordsContainingIllegalMiddleChars_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        var illegalChars = new[] { 'a', 'e', 'i', 'o', 'u' };
        var input = Array.Empty<string>();

        var actual = () => input.FilterWordsContainingIllegalMiddleChars(illegalChars);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}
