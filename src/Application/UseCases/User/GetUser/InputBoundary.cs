using Application.Contracts;

namespace Application.UseCases.User.GetUser;

public record InputBoundary(int UserId) : IUseCaseInputBoundary;
