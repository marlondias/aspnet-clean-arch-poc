using CleanArchPOC.Application.Contracts;
using CleanArchPOC.Domain.Contracts.Repository;
using CleanArchPOC.Domain.Contracts.Services;
using CleanArchPOC.Domain.ValueObjects;

namespace CleanArchPOC.Application.UseCases.User.CreateUser;

public sealed class CreateUserUseCase : IUseCaseInteractor<InputBoundary, OutputBoundary>
{
    private readonly IUserCommandsRepository _userCommandsRepository;
    private readonly IUserQueriesRepository _userQueriesRepository;
    private readonly IStringHashingService _stringHashingService;

    public CreateUserUseCase(
        IUserCommandsRepository userCommandsRepository,
        IUserQueriesRepository userQueriesRepository,
        IStringHashingService stringHashingService
    )
    {
        _userCommandsRepository = userCommandsRepository;
        _userQueriesRepository = userQueriesRepository;
        _stringHashingService = stringHashingService;
    }

    public async Task<OutputBoundary> Handle(InputBoundary input)
    {
        var name = new PersonName(input.FirstName, input.LastName);
        var email = new EmailAddress(input.EmailAddress);

        if (await _userQueriesRepository.IsEmailAddressAlreadyInUse(email))
            throw new Exception("This email address is already in use.");

        var user = new Domain.Entities.User(name, email);
        user.SetHashedPasswordFromPlainText(_stringHashingService, input.Password);

        await _userCommandsRepository.Insert(user);
        var createdUser = await _userQueriesRepository.FindByEmail(email);

        return new OutputBoundary(createdUser.Id);
    }
}
