using System;
using System.Linq;
using Workshops.AppLogic.Entities;
using Workshops.AppLogic.Repositories;
using Workshops.AppLogic.Validators;

namespace Workshops.Applogic
{
  public class ContractorService : IContractorService
  {
    private readonly IContractorRepository _contractorRepository;

    public ContractorService(IContractorRepository contractorRepository)
    {
      _contractorRepository = contractorRepository;
    }

    public void AddContractor(Contractor contractor)
    {
      if (contractor == null)
        throw new ArgumentNullException(nameof(contractor));

      Validate(contractor);

      _contractorRepository.Add(contractor);
    }

    public void UpdateContractor(Contractor contractor)
    {
      if (contractor == null)
        throw new ArgumentNullException(nameof(contractor));

      Validate(contractor);

      _contractorRepository.AddOrUpdate(contractor);
    }

    public void DeleteContractor(Contractor contractor)
    {
      if (contractor == null)
        throw new ArgumentNullException(nameof(contractor));

      _contractorRepository.Delete(contractor.Id);
    }

    public SearchResult<Contractor> FindContractor(string nip, string name)
    {
      if (string.IsNullOrWhiteSpace(nip) && string.IsNullOrWhiteSpace(name))
        throw new ArgumentNullException($"{nameof(nip)}  {nameof(name)}");

      var result = new SearchResult<Contractor>();

      if (string.IsNullOrWhiteSpace(nip))
        result.Data = _contractorRepository.GetAll().Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

      if (string.IsNullOrWhiteSpace(name))
        result.Data = _contractorRepository.GetAll().Where(x => x.NIP.Equals(nip, StringComparison.InvariantCultureIgnoreCase));
      else
      {
        result.Data = _contractorRepository.GetAll().Where(
          x => x.NIP.Equals(nip, StringComparison.InvariantCultureIgnoreCase)
               && x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
      }

      return result;
    }

    protected void Validate(Contractor contractor)
    {
      NipValidator.Validate(contractor.NIP);
      RegonValidator.Validate(contractor.REGON);

      if (string.IsNullOrWhiteSpace(contractor.Name))
      {
        throw new MissingContractorNameException();
      }

      if (string.IsNullOrWhiteSpace(contractor.Address))
      {
        throw new MissingContractorAddressException();
      }
    }
  }
}