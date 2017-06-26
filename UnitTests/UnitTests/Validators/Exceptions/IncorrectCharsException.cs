using System;

namespace Workshops.AppLogic.Validators
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