namespace Domain.Contracts;

public interface IDataTransferObject
{
  public void Fill(Dictionary<string, object> fillData);

  public Dictionary<string, object> ToDictionary();
}
