using CleanArchPOC.Database.Contexts;
using CleanArchPOC.Domain.Contracts.Repository;
using CleanArchPOC.Domain.Entities;
using CleanArchPOC.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using DbUser = CleanArchPOC.Database.Models.User;

namespace CleanArchPOC.Adapters.Services;

public sealed class UserRepository : IUserCommandsRepository, IUserQueriesRepository
{
    private readonly MainContext _context;

    public UserRepository(MainContext context)
    {
        _context = context;
    }

    public async Task Insert(User entity)
    {
        var dbUser = MapUserToDatabaseModel(entity);
        _context.Users.Add(dbUser);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User entity)
    {
        var dbUser = await _context.Users.FindAsync(entity.Id);

        if (dbUser is null)
            throw new InvalidOperationException($"User with ID {entity.Id} not found");

        dbUser.FirstName = entity.Name.FirstName;
        dbUser.LastName = entity.Name.LastName;
        dbUser.Email = entity.Email.FullAddress;
        dbUser.EmailVerifiedAt = entity.EmailVerifiedAt;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteById(int entityId)
    {
        var dbUser = await _context.Users.FindAsync(entityId);

        if (dbUser is null)
            throw new InvalidOperationException($"User with ID {entityId} not found.");

        _context.Users.Remove(dbUser);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> FindById(int entityId)
    {
        var dbUser = await _context.Users.FindAsync(entityId);
        return dbUser is null ? null : MapUserToDomainEntity(dbUser);
    }

    public async Task<User?> FindByEmail(EmailAddress emailAddress)
    {
        var dbUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == emailAddress.FullAddress);

        return dbUser is null ? null : MapUserToDomainEntity(dbUser);
    }

    public async Task<User[]> GetAll()
    {
        var dbUsers = await _context.Users.ToArrayAsync();
        return dbUsers.Select(MapUserToDomainEntity).ToArray();
    }

    public async Task<bool> IsEmailAddressAlreadyInUse(EmailAddress emailAddress)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == emailAddress.FullAddress);
    }

    private DbUser MapUserToDatabaseModel(User user)
    {
        if (user.HashedPassword is null)
            throw new InvalidDataException("A User record must have some password.");

        var dbUser = new DbUser()
        {
            FirstName = user.Name.FirstName,
            LastName = user.Name.LastName,
            Email = user.Email.FullAddress,
            Password = user.HashedPassword,
            EmailVerifiedAt = user.EmailVerifiedAt,
        };

        if (user.Id != null)
            dbUser.Id = (int)user.Id;

        return dbUser;
    }

    private User MapUserToDomainEntity(DbUser dbUser)
    {
        return new User
        {
            Id = dbUser.Id,
            Name = new PersonName(dbUser.FirstName, dbUser.LastName),
            Email = new EmailAddress(dbUser.Email),
            HashedPassword = dbUser.Password,
            EmailVerifiedAt = dbUser.EmailVerifiedAt,
            CreatedAt = dbUser.CreatedAt,
            UpdatedAt = dbUser.UpdatedAt
        };
    }

}
