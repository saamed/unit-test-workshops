using System;

namespace Workshops.Applogic
{
  public static class VatValueCalculator
  {
    public static decimal CalculateGrossValue(decimal netValue, decimal vatRate)
    {
      var result = Math.Round(netValue * (1 + vatRate) * 100, 2, MidpointRounding.AwayFromZero);

      return result;
    }
  }
}