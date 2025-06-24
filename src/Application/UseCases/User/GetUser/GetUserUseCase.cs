using Application.Contracts;
using Domain.Contracts.Repository;

namespace Application.UseCases.User.GetUser;

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
        return new OutputBoundary(user);
    }
}
