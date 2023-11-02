using FigureLibrary;
using FluentAssertions;

namespace FigureLibTests;

public class AreaCalculatorTests
{
    [Theory]
    [InlineData(10d)]
    [InlineData(15d)]
    [InlineData(18d)]
    public void Circle_Area_Calculation_Is_Valid(double radius)
    {
        // Arrange
        var validRoundedArea = Math.Round(Math.PI * Math.Pow(radius, 2), 2);
        var circle = new Circle()
        {
            Radius = radius
        };
        
        // Act
        var roundedCircleArea = Math.Round(AreaCalculator.CalculateArea(circle), 2);
        
        // Assert
        roundedCircleArea.Should().Be(validRoundedArea);
    }
    
    [Theory]
    [InlineData(10d, 15d, 25d)]
    [InlineData(15d, 103d, 14d)]
    [InlineData(-12d, 13d, 14d)]
    public void Triangle_Area_With_Invalid_Sides_Cant_Be_Calculated(double sideA, double sideB, double sideC)
    {
        var triangle = new Triangle
        {
            SideA = sideA,
            SideB = sideB,
            SideC = sideC
        };
        Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateArea(triangle));
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    [InlineData(8, 15, 17)]
    public void Right_Triangle_Checking_Is_Valid(double sideA, double sideB, double sideC)
    {
        // Arrange
        var verifier = new RightTriangleVerifier();
        var triangle = new Triangle()
        {
            SideA = sideA,
            SideB = sideB,
            SideC = sideC
        };
        
        // Act
        var isRightTriangle = verifier.Verify(triangle);

        // Assert
        isRightTriangle.Should().BeTrue();
    }
}