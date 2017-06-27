using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Workshops.Applogic;
using Workshops.AppLogic.Entities;
using Workshops.AppLogic.Repositories;

namespace Workshops.Excercises
{
  [TestFixture]
  public class ContractorTests
  {
    [Test]
    public void add_contractor_should_execute_contractor_repository_add()
    {
      // Arrange
      Mock<IContractorRepository> contractorRepositoryMock = new Mock<IContractorRepository>();

      // konfiguracja mocka
      contractorRepositoryMock
        .Setup(m => m.Add(It.IsAny<Contractor>())) // przygotowujemy metodę Add. Przyjmuje dowolny obiekt typu Contractor
        .Returns(() => new Random().Next()) // zwraca losową liczbę
        .Verifiable(); // będziemy mogli sprawdzić, czy została wywołana

      Contractor contractor = new Contractor()
      {
        // Przygotowanie obiektu Contractor
      };

      // tworzymy instancję klasy ContractorService i przekazujemy mock jako parametr
      IContractorService service = new ContractorService(contractorRepositoryMock.Object);

      // Act
      service.AddContractor(contractor);

      // Assert
      contractorRepositoryMock.Verify(); // sprawdzamy, czy wszystkie przygotowane metody zostały wykonane
    }

  }
}
