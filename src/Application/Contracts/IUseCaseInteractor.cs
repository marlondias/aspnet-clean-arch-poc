namespace Application.Contracts;

public interface IUseCaseInteractor
{
    public IUseCaseOutputBoundary Handle(IUseCaseInputBoundary input);
}
