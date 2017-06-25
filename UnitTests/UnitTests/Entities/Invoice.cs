using System;
using Workshops.Applogic;

namespace Workshops.AppLogic.Entities
{
  public class Invoice : Entity
  {
    public string InvoiceNumber { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime? PaidDate { get; set; }

    public decimal NetValue { get; set; }

    public decimal GrossValue { get; set; }

    public decimal VatRate { get; set; }

    public Contractor Contractor { get; set; }
  }
}