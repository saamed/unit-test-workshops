using System;
using NUnit.Framework;
using Workshops.AppLogic.Validators;
using Workshops.AppLogic.Validators.Exceptions;

namespace Workshops.Excercises
{
  [TestFixture]
  public class NipValidatorTests
  {
    [Test]
    public void does_not_throw_exception_on_correct_nip()
    {
      // Arrange
      var nip = "4928963046";

      Action action = () =>
      {
        // Act
        NipValidator.Validate(nip);
      };

      // Assert
      Assert.DoesNotThrow(() => action());
    }

    [TestCase("8755730102")]
    [TestCase("2524136117")]
    public void test_case_does_not_throw_exception_on_correct_nip(string providedNip)
    {
      // Arrange
      var nip = providedNip;

      Action action = () =>
      {
        // Act
        NipValidator.Validate(nip);
      };

      // Assert
      Assert.DoesNotThrow(() => action());
    }

    [TestCaseSource("TestCaseData")]
    public void test_case_source_does_not_throw_exception_on_correct_nip(string providedNip)
    {
      // Arrange
      var nip = providedNip;

      Action action = () =>
      {
        // Act
        NipValidator.Validate(nip);
      };

      // Assert
      Assert.DoesNotThrow(() => action());
    }

    [Test]
    public void throws_WrongLengthException_when_provided_nip_is_too_short()
    {
      // Arrange
      var nip = "4928";

      Action action = () =>
      {
        // Act
        NipValidator.Validate(nip);
      };

      // Assert
      Assert.Throws<WrongLengthException>(() => action());
    }

    private static object TestCaseData()
    {
      return new[]
      {
          "8775510438",
          "3980338406",
          "5959912688"
        };
    }
  }
}
