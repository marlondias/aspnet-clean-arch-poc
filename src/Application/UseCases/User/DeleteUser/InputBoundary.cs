using Application.Contracts;

namespace Application.UseCases.User.DeleteUser;

public record InputBoundary(int UserId) : IUseCaseInputBoundary;
