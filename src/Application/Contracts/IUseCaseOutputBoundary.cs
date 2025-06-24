namespace Application.Contracts;

public interface IUseCaseOutputBoundary
{
    public string GetMessage();

    public Dictionary<string, string> ToDictionary();
}
