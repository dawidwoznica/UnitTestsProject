namespace MyProject.Tests;

public class BmiDeterminatorTests
{
    [Theory]
    [InlineData(5.0, BmiClassification.Underweight)]
    [InlineData(10.0, BmiClassification.Underweight)]
    [InlineData(15.0, BmiClassification.Underweight)]
    [InlineData(18.0, BmiClassification.Underweight)]
    [InlineData(24.0, BmiClassification.Normal)]
    [InlineData(19.0, BmiClassification.Normal)]
    [InlineData(18.9, BmiClassification.Normal)]
    [InlineData(25.8, BmiClassification.Overweight)]
    [InlineData(28.8, BmiClassification.Overweight)]
    [InlineData(30.8, BmiClassification.Obesity)]
    [InlineData(34.9, BmiClassification.Obesity)]
    [InlineData(35.5, BmiClassification.ExtremeObesity)]
    [InlineData(55.9, BmiClassification.ExtremeObesity)]
    public void DetermineBmi_ForGivenBmi_ReturnCorrectClassification(double bmi, BmiClassification bmiClassification)
    {
        var bmiDeterminator = new BmiDeterminator();
        var result = bmiDeterminator.DetermineBmi(bmi);

        Assert.Equal(bmiClassification, result);
    }
}