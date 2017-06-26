using System;

namespace Workshops.AppLogic.Validators
{
  public class NotValidException : Exception
  {
    public string Value { get; }

    public NotValidException(string value)
    {
      Value = value;
    }

    public NotValidException()
    {
    }
  }
}