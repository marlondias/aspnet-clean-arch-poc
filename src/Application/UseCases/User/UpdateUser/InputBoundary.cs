using CleanArchPOC.Application.Contracts;

namespace CleanArchPOC.Application.UseCases.User.UpdateUser;

public record InputBoundary(
    int UserId,
    string FirstName,
    string? LastName,
    string EmailAddress,
    string? Password
) : IUseCaseInputBoundary;
