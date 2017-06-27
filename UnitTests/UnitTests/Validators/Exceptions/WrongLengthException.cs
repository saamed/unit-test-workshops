using System;

namespace Workshops.AppLogic.Validators.Exceptions
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