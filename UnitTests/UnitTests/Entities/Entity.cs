namespace Workshops.AppLogic.Entities
{
  public abstract class Entity
  {
    public long Id { get; set; }


    public override bool Equals(object obj)
    {
      var entity = obj as Entity;

      if (entity == null)
        return false;

      if (entity.GetType() != this.GetType())
        return false;

      return this.Id == entity.Id;
    }

    protected bool Equals(Entity other)
    {
      return Id == other.Id;
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }
  }
}