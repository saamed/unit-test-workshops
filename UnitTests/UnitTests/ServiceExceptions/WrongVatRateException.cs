using System;

namespace Workshops.Applogic
{
  public class WrongVatRateException : Exception
  {
    public decimal WrongVatRate { get; set; }

    public WrongVatRateException()
    {
    }

    public WrongVatRateException(decimal wrongVatRate)
    {
      WrongVatRate = wrongVatRate;
    }
  }
}