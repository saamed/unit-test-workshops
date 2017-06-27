using Workshops.AppLogic.Entities;

namespace Workshops.Applogic
{
  public interface IContractorService
  {
    void AddContractor(Contractor contractor);
    void UpdateContractor(Contractor contractor);
    void DeleteContractor(Contractor contractor);
    SearchResult<Contractor> FindContractor(string nip, string name);
  }
}