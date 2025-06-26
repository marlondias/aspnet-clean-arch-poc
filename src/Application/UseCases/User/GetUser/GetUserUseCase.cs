using CleanArchPOC.Application.Contracts;
using CleanArchPOC.Domain.Contracts.Repository;
using CleanArchPOC.Domain.Exceptions;

namespace CleanArchPOC.Application.UseCases.User.GetUser;

public sealed class GetUserUseCase : IUseCaseInteractor<InputBoundary, OutputBoundary>
{
    private readonly IUserQueriesRepository _userQueriesRepository;

    public GetUserUseCase(IUserQueriesRepository userQueriesRepository)
    {
        _userQueriesRepository = userQueriesRepository;
    }

    public async Task<OutputBoundary> Handle(InputBoundary input)
    {
        var user = await _userQueriesRepository.FindById(input.UserId);

        if (user is null)
            throw new EntityNotFoundException("User not found.");

        return new OutputBoundary(user);
    }
}
