namespace Exercise.Tests;

using FluentAssertions;

public class ListHelperTests
{
    [Theory]
    [ClassData(typeof(ListHelperTestData))]
    public void FilterOddNumber_ForGivenInput_ReturnsListWithoutEvenNumbers(List<int> input, List<int> expectedResult)
    {
        var result = ListHelper.FilterOddNumber(input);

        result.Should().BeEquivalentTo(expectedResult);
    }
}