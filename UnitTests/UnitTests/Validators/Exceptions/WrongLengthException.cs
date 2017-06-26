using System;

namespace Workshops.AppLogic.Validators
{
  public class WrongLengthException : Exception
  {
    public string Value { get; }

    public WrongLengthException()
    {
    }

    public WrongLengthException(string value)
    {
      Value = value;
    }
  }
}