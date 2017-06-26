namespace Workshops.AppLogic.Entities
{
  public class InvoiceContractor : Contractor
  {
    public Invoice Invoice { get; set; }
    public Contractor Contractor { get; set; }
  }
}