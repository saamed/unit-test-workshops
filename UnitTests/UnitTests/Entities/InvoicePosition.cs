namespace Workshops.AppLogic.Entities
{
  public class InvoicePosition : Entity
  {
    public string Name { get; set; }
    public decimal NetValue { get; set; }
    public decimal GrossValue { get; set; }
    public decimal VatRate { get; set; }

    public Invoice Invoice { get; set; }
  }
}