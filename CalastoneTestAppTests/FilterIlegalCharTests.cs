namespace CalastoneTestAppTests;

public class FilterIlegalCharTests
{
    [Fact]
    public void FilterWordsContainingIlegalChar_WhenGivenValidChar_ShouldReturnWordsWithoutIlegalChar()
    {
        // arrange
        var ilegalChar = 'e';
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIlegalChar(ilegalChar);

        // assert
        var expected = 4;
        actual.Should().NotBeNull();
        actual.Count().Should().Be(expected);
    }

    [Fact]
    public void FilterWordsContainingIlegalChar_WhenGivenInvalidChar_ShouldReturnUnchangedList()
    {
        // arrange
        var ilegalChar = 'z';
        var input = new[] { "this", "is", "the", "test", "input", "to", "use" };

        // act
        var actual = input.FilterWordsContainingIlegalChar(ilegalChar);

        // assert
        var expected = input.Length;
        actual.Should().NotBeNull();
        actual.Count().Should().Be(expected);
    }

    [Fact]
    public void FilterWordsContainingIlegalChar_WhenGivenEmptyWordsCollection_ShouldThrowException()
    {
        var ilegalChar = 'e';
        var input = Array.Empty<string>();

        var actual = () => input.FilterWordsContainingIlegalChar(ilegalChar);

        // assert
        var exception = Assert.Throws<InvalidOperationException>(actual);
        Assert.Equal("Input words array contains no elements", exception.Message);
    }
}