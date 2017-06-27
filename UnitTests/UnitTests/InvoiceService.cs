using System;
using System.Linq;
using Workshops.AppLogic.Entities;
using Workshops.AppLogic.Repositories;

namespace Workshops.Applogic
{
  public class InvoiceService : IInvoiceService
  {
    private const bool ShouldValidate = true;

    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceService(IInvoiceRepository invoiceRepository)
    {
      _invoiceRepository = invoiceRepository;
    }

    public void AddInvoice(Invoice invoice)
    {
      if (invoice == null)
        throw new ArgumentException("invoice");

      ValidateInvoice(invoice);

      _invoiceRepository.Add(invoice);
    }

    public void UpdateInvoice(Invoice invoice)
    {
      if (invoice == null)
        throw new ArgumentException("invoice");

      ValidateInvoice(invoice);

      _invoiceRepository.AddOrUpdate(invoice);
    }

    public void DeleteInvoice(Invoice invoice)
    {
      if (invoice == null)
        throw new ArgumentException("invoice");

      _invoiceRepository.Delete(invoice.Id);
    }

    public SearchResult<Invoice> FindInvoice(string number)
    {
      if (string.IsNullOrWhiteSpace(number))
        throw new ArgumentException("number");

      var invoices = _invoiceRepository.GetAll()
        .Where(x => x.InvoiceNumber.Equals(number, StringComparison.InvariantCultureIgnoreCase));

      return new SearchResult<Invoice>()
      {
        Data = invoices
      };
    }

    public SearchResult<Invoice> FindByContractorNip(string nip)
    {
      if (string.IsNullOrWhiteSpace(nip))
        throw new ArgumentException("nip");

      var invoices = _invoiceRepository.GetAll()
        .Where(x => x.Contractor.NIP.Equals(nip, StringComparison.InvariantCultureIgnoreCase));

      return new SearchResult<Invoice>()
      {
        Data = invoices
      };
    }

    protected void ValidateInvoice(Invoice invoice)
    {
      if (!ShouldValidate)
        return;

      if (string.IsNullOrWhiteSpace(invoice.InvoiceNumber))
      {
        throw new MissingInvoiceNumberException();
      }

      if (invoice.NetValue <= 0)
      {
        throw new InvoiceNetValueMustBePositiveException();
      }

      if (invoice.GrossValue <= 0)
      {
        throw new InvoiceGrossValueMustBePositiveException();
      }

      if (!invoice.Positions.Any())
      {
        throw new InvoiceMustHavePositionsException();
      }

      if (invoice.Contractor == null)
      {
        throw new InvoiceMustHaveContractorException();
      }

      foreach (var position in invoice.Positions)
      {
        ValidatePosition(position);
      }
    }

    protected void ValidatePosition(InvoicePosition position)
    {
      if (string.IsNullOrWhiteSpace(position.Name))
      {
        throw new MissingPositionNameException();
      }

      if (position.NetValue <= 0)
      {
        throw new PositionNetValueMustBePositiveException();
      }

      if (position.GrossValue <= 0)
      {
        throw new PositionGrossValueMustBePositiveException();
      }

      if (position.VatRate >= 0 && position.VatRate < 1)
      {
        throw new WrongVatRateException(position.VatRate);
      }

      var grossValue = VatValueCalculator.CalculateGrossValue(position.NetValue, position.VatRate);

      if (position.GrossValue != grossValue)
      {
        throw new WrongPositionGrossValueException(position.NetValue, position.VatRate, position.GrossValue);
      }
    }

  }
}