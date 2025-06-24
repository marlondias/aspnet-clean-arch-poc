using CleanArchPOC.Application.Contracts;

namespace CleanArchPOC.Application.UseCases.User.CreateUser;

public record OutputBoundary(int UserId) : IUseCaseOutputBoundary;
