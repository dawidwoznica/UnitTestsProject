namespace Exercise.Tests;

using FluentAssertions;

public class ValidatorTests
{
    [Theory]
    [MemberData(nameof(TestDateRanges))]
    public void ValidateOverlapping_ForOverlappingDateRanges_ReturnsFalse(List<DateRange> ranges)
    {
        var validator = new Validator();
        var input = new DateRange(new DateTime(2020, 1, 10), new DateTime(2020, 1, 20));

        var result = validator.ValidateOverlapping(ranges, input);

        result.Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(TestDateRanges))]
    public void ValidateOverlapping_ForNonOverlappingDateRanges_ReturnsTrue(List<DateRange> ranges)
    {
        var validator = new Validator();
        var input = new DateRange(new DateTime(2020, 1, 26), new DateTime(2020, 1, 30));

        var result = validator.ValidateOverlapping(ranges, input);

        result.Should().BeTrue();
    }


    public static IEnumerable<object[]> TestDateRanges()
    {
        yield return
        [
            new List<DateRange>
            {
                new(new DateTime(2020, 1, 1), new DateTime(2020, 1, 15)),
                new(new DateTime(2020, 2, 1), new DateTime(2020, 2, 15))
            }
        ];

        yield return
        [
            new List<DateRange> { new(new DateTime(2020, 1, 15), new DateTime(2020, 1, 25)) }
        ];

        yield return
        [
            new List<DateRange> { new(new DateTime(2020, 1, 8), new DateTime(2020, 1, 25)) }
        ];

        yield return
        [
            new List<DateRange> { new(new DateTime(2020, 1, 12), new DateTime(2020, 1, 14)) }
        ];
    }
}