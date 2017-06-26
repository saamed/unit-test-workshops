using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshops.Applogic;

namespace Workshops.Tests.MSTest
{
  [TestClass]
  public class VatValueCalculatorTests
  {
    [TestMethod]
    public void should_calculate_proper_value()
    {
      const decimal netValue = 15;
      const decimal vatRate = 0.23m;

      var expectedValue = 18.45M;

      var calculatedValue = VatValueCalculator.CalculateGrossValue(netValue, vatRate);

      Assert.AreEqual(expectedValue, calculatedValue);
    }
  }
}
