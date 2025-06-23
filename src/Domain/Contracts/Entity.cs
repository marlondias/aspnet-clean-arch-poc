namespace Domain.Contracts;

public abstract class Entity
{
  public int Id { get; set; }

  public abstract Dictionary<string, object> ToDictionary();
}
