using System;
using System.Collections.Generic;

namespace Workshops.AppLogic.Entities
{
  public class Invoice : Entity
  {
    private List<InvoicePosition> _positions;
    
    public string InvoiceNumber { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime PaymentDate { get; set; }

    public DateTime? PaidDate { get; set; }

    public decimal NetValue { get; set; }

    public decimal GrossValue { get; set; }

    public decimal DueValue { get; set; }

    public InvoiceContractor Contractor { get; set; }

    public bool IsDraft { get; set; }

    public IEnumerable<InvoicePosition> Positions
    {
      get { return _positions; }
    }

    public void AddPosition(InvoicePosition position)
    {
      _positions.Add(position);
      position.Invoice = this;
    }

    public void RemovePosition(InvoicePosition position)
    {
      _positions.Remove(position);
      position.Invoice = null;
    }

    public Invoice()
    {
      _positions = new List<InvoicePosition>();
    }
  }
}