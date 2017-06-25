namespace Workshops.Applogic
{
  public static class VatValueCalculator
  {
    public static decimal CalculateGrossValue(decimal netValue)
    {
      return netValue * 1.23M;
    }
  }
}