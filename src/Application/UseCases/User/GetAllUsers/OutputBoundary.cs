using Application.Contracts;

namespace Application.UseCases.User.GetAllUsers;

public record OutputBoundary(Domain.Entities.User[] Users) : IUseCaseOutputBoundary;
