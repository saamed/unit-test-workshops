using Workshops.Applogic;
using NUnit.Framework;

namespace Workshops.Tests.NUnit
{
  [TestFixture]
  public class VatValueCalculatorTests
  {
    [Test]
    public void calculates_proper_value_for_23_percent()
    {
      var expectedValue = 18.45M;
      const decimal vatRate = 0.23M;

      // Arrange
      decimal netValue = 15;


      // Act
      var calculatedValue = VatValueCalculator.CalculateGrossValue(netValue, vatRate);


      // Assert
      Assert.That(expectedValue, Is.Not.EqualTo(calculatedValue));
    }
  }
}
