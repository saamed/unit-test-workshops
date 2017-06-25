using Workshops.Applogic;
using NUnit.Framework;

namespace Workshops.Tests.NUnit
{
  [TestFixture]
  public class VatValueCalculatorTests
  {
    [Test]
    public void should_calculate_proper_value()
    {
      const decimal netValue = 15;

      var expectedValue = 18.45M;

      var calculatedValue = VatValueCalculator.CalculateGrossValue(netValue);

      Assert.That(expectedValue, Is.EqualTo(calculatedValue));
    }
  }
}
