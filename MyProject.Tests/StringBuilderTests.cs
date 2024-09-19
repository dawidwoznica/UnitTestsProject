namespace MyProject.Tests;

using System.Text;

public class StringBuilderTests
{
    [Fact]
    public void Append_ForTwoStrings_ReturnsConcatenatedString()
    {
        //arrange

        var sb = new StringBuilder();

        //act

        sb.Append("test");
        sb.Append("test2");

        var result = sb.ToString();

        //assert

        Assert.Equal("testtest2", result);
    }
}