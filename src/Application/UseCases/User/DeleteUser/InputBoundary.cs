using CleanArchPOC.Application.Contracts;

namespace CleanArchPOC.Application.UseCases.User.DeleteUser;

public record InputBoundary(int UserId) : IUseCaseInputBoundary;
