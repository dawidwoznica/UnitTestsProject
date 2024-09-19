namespace MyProject.Tests;

using FluentAssertions;
using Moq;
using Service;

public class ResultServiceTests
{
    [Fact]
    public void SetRecentOverweightResult_ForOverweightResult_UpdatesProperty()
    {
        var result = new BmiResult { BmiClassification = BmiClassification.Overweight };
        var resultService = new ResultService(new ResultRepository());

        resultService.SetRecentOverweightResult(result);

        resultService.RecentOverweightResult.Should().Be(result);
    }

    [Fact]
    public void SetRecentOverweightResult_ForNonOverweightResult_NotUpdatesProperty()
    {
        var result = new BmiResult { BmiClassification = BmiClassification.Normal };
        var resultService = new ResultService(new ResultRepository());

        resultService.SetRecentOverweightResult(result);

        resultService.RecentOverweightResult.Should().BeNull();
    }

    [Fact]
    public async Task SaveUnderweightResultAsync_ForUnderweightResult_InvokesSaveResultAsync()
    {
        var result = new BmiResult { BmiClassification = BmiClassification.Underweight };
        var resultRepositoryMock = new Mock<IResultRepository>();
        var resultService = new ResultService(resultRepositoryMock.Object);

        await resultService.SaveUnderweightResultAsync(result);

        resultRepositoryMock.Verify(mock => mock.SaveResultAsync(result), Times.Once);
    }

    [Fact]
    public async Task SaveUnderweightResultAsync_ForNonUnderweightResult_NotInvokesSaveResultAsync()
    {
        var result = new BmiResult { BmiClassification = BmiClassification.Normal };
        var resultRepositoryMock = new Mock<IResultRepository>();
        var resultService = new ResultService(resultRepositoryMock.Object);

        await resultService.SaveUnderweightResultAsync(result);

        resultRepositoryMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);
    }
}