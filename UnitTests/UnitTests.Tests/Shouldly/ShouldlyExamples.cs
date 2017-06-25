using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace Workshops.Tests.Shouldly
{
  [TestFixture]
  public class ShouldlyExamples
  {
    [Test]
    public void ShouldBeTrue()
    {
      var a = 1 * 3;
      var b = 9/3;

      var value = a == b;

      value.ShouldBe(true);
      Action action = () => { throw new Exception();};

      action.ShouldThrow<Exception>();
    }
  }
}
