namespace CleanArchPOC.Application.Contracts;

public interface IUseCaseInteractor<I, O>
    where I : IUseCaseInputBoundary
    where O : IUseCaseOutputBoundary
{
    public Task<O> Handle(I input);
}
