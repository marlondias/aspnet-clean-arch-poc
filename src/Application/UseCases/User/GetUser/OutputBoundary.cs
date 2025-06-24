using Application.Contracts;

namespace Application.UseCases.User.GetUser;

public record OutputBoundary(Domain.Entities.User User) : IUseCaseOutputBoundary;
