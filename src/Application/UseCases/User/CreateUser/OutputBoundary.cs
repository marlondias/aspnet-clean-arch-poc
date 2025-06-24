using Application.Contracts;

namespace Application.UseCases.User.CreateUser;

public record OutputBoundary(int UserId) : IUseCaseOutputBoundary;
