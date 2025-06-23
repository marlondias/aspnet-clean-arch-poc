namespace Domain.Contracts;

public interface IValueObject
{
  public Dictionary<string, object> ToDictionary();
}
