using CleanArchPOC.Application.Contracts;

namespace CleanArchPOC.Application.UseCases.User.CreateUser;

public record InputBoundary(
    string FirstName,
    string LastName,
    string EmailAddress,
    string Password
) : IUseCaseInputBoundary;
