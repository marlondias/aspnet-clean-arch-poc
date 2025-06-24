using CleanArchPOC.Application.Contracts;

namespace CleanArchPOC.Application.UseCases.User.GetAllUsers;

public record OutputBoundary(Domain.Entities.User[] Users) : IUseCaseOutputBoundary;
