using System;

namespace Workshops.AppLogic.Validators.Exceptions
{
  public class IncorrectCharsException : Exception
  {
    public string Value { get; }

    public IncorrectCharsException()
    {
    }

    public IncorrectCharsException(string value)
    {
      Value = value;
    }
  }
}