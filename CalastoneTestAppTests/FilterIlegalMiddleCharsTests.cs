namespace CalastoneTestAppTests;

public class FilterIlegalMiddleCharsTests
{
    [Fact]
    public void FilterWordsContainingIlegalMiddleChars_WhenGivenValidChars_ShouldReturnWordsWithoutIlegalChars()
    {
        // arrange
        var ilegalChars = new[] { 'a', 'e', 'i', 'o', 'u' };
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIlegalMiddleChars(ilegalChars);

        // assert
        var expected = 5;
        actual.Should().NotBeNull();
        actual.Count().Should().Be(expected);
    }

    [Fact]
    public void FilterWordsContainingIlegalMiddleChars_WhenGivenInvalidChars_ShouldReturnUnchangedList()
    {
        // arrange
        var ilegalChars = new[] { 'z' };
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIlegalMiddleChars(ilegalChars);

        // assert
        var expected = input.Length;
        actual.Should().NotBeNull();
        actual.Count().Should().Be(expected);
    }

    [Fact]
    public void FilterWordsContainingIlegalMiddleChars_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        var ilegalChars = new[] { 'a', 'e', 'i', 'o', 'u' };
        var input = Array.Empty<string>();

        var actual = () => input.FilterWordsContainingIlegalMiddleChars(ilegalChars);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}
