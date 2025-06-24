using CleanArchPOC.Application.Contracts;
using CleanArchPOC.Domain.Contracts.Repository;

namespace CleanArchPOC.Application.UseCases.User.GetAllUsers;

public sealed class GetAllUsersUseCase : IUseCaseInteractor<InputBoundary, OutputBoundary>
{
    private readonly IUserQueriesRepository _userQueriesRepository;

    public GetAllUsersUseCase(IUserQueriesRepository userQueriesRepository)
    {
        _userQueriesRepository = userQueriesRepository;
    }

    public async Task<OutputBoundary> Handle(InputBoundary input)
    {
        var users = await _userQueriesRepository.GetAll();
        return new OutputBoundary(users);
    }
}
