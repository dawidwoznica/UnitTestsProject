namespace Exercise.Tests;

using FluentAssertions;

public class StringHelperTests
{
    [Theory]
    [InlineData("ala ma kota", "kota ma ala")]
    [InlineData("to jest test", "test jest to")]
    [InlineData(" ", " ")]
    [InlineData("", "")]
    public void ReverseWords_ForGivenString_ReturnsReversedResult(string input, string reversed)
    {
        var result = StringHelper.ReverseWords(input);

        result.Should().Be(reversed);
    }

    [Theory]
    [InlineData("ala")]
    [InlineData("ALA")]
    [InlineData("OlO")]
    [InlineData("aLa")]
    [InlineData("madam")]
    [InlineData("KAjAK")]
    public void IsPalindrome_ForPalindromeWord_ReturnsTrue(string input)
    {
        var result = StringHelper.IsPalindrome(input);

        result.Should().Be(true);
    }

    [Theory]
    [InlineData("ola")]
    [InlineData("Ala")]
    [InlineData("test")]
    [InlineData("oLO")]
    [InlineData("KaJak")]
    public void IsPalindrome_ForNonPalindromeWord_ReturnsFalse(string input)
    {
        var result = StringHelper.IsPalindrome(input);

        result.Should().Be(false);
    }
}