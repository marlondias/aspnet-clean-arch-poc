using CleanArchPOC.Application.Contracts;
using CleanArchPOC.Domain.Contracts.Repository;

namespace CleanArchPOC.Application.UseCases.User.DeleteUser;

public sealed class DeleteUserUseCase : IUseCaseInteractor<InputBoundary, OutputBoundary>
{
    private readonly IUserCommandsRepository _userCommandsRepository;

    public DeleteUserUseCase(IUserCommandsRepository userCommandsRepository)
    {
        _userCommandsRepository = userCommandsRepository;
    }

    public async Task<OutputBoundary> Handle(InputBoundary input)
    {
        await _userCommandsRepository.DeleteById(input.UserId);
        return new OutputBoundary();
    }
}
