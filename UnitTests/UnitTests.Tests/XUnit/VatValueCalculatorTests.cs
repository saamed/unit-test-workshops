using Workshops.Applogic;
using Xunit;

namespace Workshops.Tests.XUnit
{
  public class VatValueCalculatorTests
  {
    [Fact]
    public void should_calculate_proper_value()
    {
      const decimal netValue = 15;

      var expectedValue = 18.45M;

      var calculatedValue = VatValueCalculator.CalculateGrossValue(netValue);

      Assert.Equal(expectedValue, calculatedValue);
    }
  }
}
