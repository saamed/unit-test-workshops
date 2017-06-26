using System;

namespace Workshops.Applogic
{
  public class WrongPositionGrossValueException : Exception
  {
    public decimal NetValue { get; set; }
    public decimal VatRate { get; set; }
    public decimal WrongGrossValue { get; set; }

    public WrongPositionGrossValueException()
    {
    }

    public WrongPositionGrossValueException(decimal netValue, decimal vatRate, decimal wrongGrossValue)
    {
      NetValue = netValue;
      VatRate = vatRate;
      WrongGrossValue = wrongGrossValue;
    }
  }
}