using CleanArchPOC.Application.Contracts;

namespace CleanArchPOC.Application.UseCases.User.GetUser;

public record OutputBoundary(Domain.Entities.User User) : IUseCaseOutputBoundary;
