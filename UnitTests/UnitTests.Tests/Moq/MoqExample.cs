using System.Linq;
using Moq;
using NUnit.Framework;
using Workshops.AppLogic.Entities;
using Workshops.AppLogic.Repositories;

namespace Workshops.Tests.Moq
{
  [TestFixture]
  public class MoqExample
  {
    [Test]
    public void SetupGetAll()
    {
      var mock = new Mock<IInvoiceRepository>();
      mock.Setup(x => x.GetAll()).Returns(new[]
        {
          new Invoice() {Id = 1, InvoiceNumber = "FV/01/2017"}, new Invoice() {Id = 2, InvoiceNumber = "FV/02/2017"},
        })
        .Verifiable();

      Assert.That(mock.Object.GetAll().Count(), Is.EqualTo(2));

      mock.Verify();
    }
  }
}
