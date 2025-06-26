using Microsoft.AspNetCore.Mvc;
using CleanArchPOC.Domain.Contracts.Repository;
using CleanArchPOC.Domain.Contracts.Services;
using CleanArchPOC.Domain.Entities;
using CleanArchPOC.Application.UseCases.User.GetAllUsers;
using CleanArchPOC.Application.UseCases.User.GetUser;
using CleanArchPOC.Application.UseCases.User.CreateUser;
using CleanArchPOC.Application.UseCases.User.UpdateUser;
using CleanArchPOC.Application.UseCases.User.DeleteUser;
using GetAllUsersInputBoundary = CleanArchPOC.Application.UseCases.User.GetAllUsers.InputBoundary;
using GetUserInputBoundary = CleanArchPOC.Application.UseCases.User.GetUser.InputBoundary;
using CreateUserInputBoundary = CleanArchPOC.Application.UseCases.User.CreateUser.InputBoundary;
using UpdateUserInputBoundary = CleanArchPOC.Application.UseCases.User.UpdateUser.InputBoundary;
using DeleteUserInputBoundary = CleanArchPOC.Application.UseCases.User.DeleteUser.InputBoundary;

namespace CleanArchPOC.Adapters.Http.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserCommandsRepository _userCommandsRepository;
    private readonly IUserQueriesRepository _userQueriesRepository;
    private readonly IStringHashingService _stringHashingService;

    public UsersController(
        IUserCommandsRepository userCommandsRepository,
        IUserQueriesRepository userQueriesRepository,
        IStringHashingService stringHashingService
    )
    {
        _userCommandsRepository = userCommandsRepository;
        _userQueriesRepository = userQueriesRepository;
        _stringHashingService = stringHashingService;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<GetUserResponseDto>>> GetAll()
    {
        var useCase = new GetAllUsersUseCase(_userQueriesRepository);

        try
        {
            var input = new GetAllUsersInputBoundary();
            var output = await useCase.Handle(input);
            var usersDtos = output.Users.Select(user => ConvertUserEntityToDTO(user)).ToArray();
            return Ok(usersDtos);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserResponseDto>> GetOne([FromRoute] int id)
    {
        var useCase = new GetUserUseCase(_userQueriesRepository);

        try
        {
            var input = new GetUserInputBoundary(id);
            var output = await useCase.Handle(input);
            return Ok(ConvertUserEntityToDTO(output.User));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponseDto>> Create([FromBody] CreateUserRequestDTO requestBody)
    {
        var useCase = new CreateUserUseCase(
            _userCommandsRepository,
            _userQueriesRepository,
            _stringHashingService
        );

        try
        {
            var input = new CreateUserInputBoundary(
                requestBody.firstName,
                requestBody.lastName,
                requestBody.emailAddress,
                requestBody.password
            );
            var output = await useCase.Handle(input);

            return CreatedAtAction(
                nameof(GetOne),
                new { id = output.UserId },
                new { id = output.UserId, createdAt = output.CreatedAt }
            );
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDTO requestBody)
    {
        var useCase = new UpdateUserUseCase(
            _userCommandsRepository,
            _userQueriesRepository,
            _stringHashingService
        );

        try
        {
            var input = new UpdateUserInputBoundary(
                id,
                requestBody.firstName,
                requestBody.lastName,
                requestBody.emailAddress,
                requestBody.password
            );
            var output = await useCase.Handle(input);
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var useCase = new DeleteUserUseCase(_userCommandsRepository);

        try
        {
            var input = new DeleteUserInputBoundary(id);
            var output = await useCase.Handle(input);
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    private GetUserResponseDto ConvertUserEntityToDTO(User user)
    {
        return new GetUserResponseDto
        {
            id = user.Id ?? 0,
            firstName = user.Name.FirstName,
            lastName = user.Name.LastName,
            emailAddress = user.Email.FullAddress,
            createdAt = user.CreatedAt,
            updatedAt = user.UpdatedAt,
            emailVerifiedAt = user.EmailVerifiedAt
        };
    }
}
