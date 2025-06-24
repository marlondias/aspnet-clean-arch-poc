using CleanArchPOC.Application.Contracts;

namespace CleanArchPOC.Application.UseCases.User.GetUser;

public record InputBoundary(int UserId) : IUseCaseInputBoundary;
