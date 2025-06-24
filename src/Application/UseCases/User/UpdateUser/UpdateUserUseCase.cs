using CleanArchPOC.Application.Contracts;
using CleanArchPOC.Domain.Contracts.Repository;
using CleanArchPOC.Domain.Contracts.Services;
using CleanArchPOC.Domain.ValueObjects;

namespace CleanArchPOC.Application.UseCases.User.UpdateUser;

public sealed class UpdateUserUseCase : IUseCaseInteractor<InputBoundary, OutputBoundary>
{
    private readonly IUserCommandsRepository _userCommandsRepository;
    private readonly IUserQueriesRepository _userQueriesRepository;
    private readonly IStringHashingService _stringHashingService;

    public UpdateUserUseCase(
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
        var user = await _userQueriesRepository.FindById(input.UserId);
        if (user is null)
            throw new Exception($"The is no user with ID {input.UserId}.");

        var name = new PersonName(input.FirstName, input.LastName);
        if (name != user.Name)
            user.Name = name;

        var email = new EmailAddress(input.EmailAddress);
        if (email != user.Email)
        {
            if (await _userQueriesRepository.IsEmailAddressAlreadyInUse(email))
                throw new Exception("This email address is already in use.");

            user.Email = email;
        }

        if (input.Password is not null)
            user.SetHashedPasswordFromPlainText(_stringHashingService, input.Password);

        await _userCommandsRepository.Update(user);

        return new OutputBoundary();
    }
}
