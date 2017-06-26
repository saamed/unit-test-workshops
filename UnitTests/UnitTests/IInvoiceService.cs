using Workshops.AppLogic.Entities;

namespace Workshops.Applogic
{
  public interface IInvoiceService
  {
    void AddInvoice(Invoice invoice);
    void UpdateInvoice(Invoice invoice);
    void DeleteInvoice(Invoice invoice);
    SearchResult<Invoice> FindInvoice(string number);
    SearchResult<Invoice> FindByContractorNip(string nip);
  }
}