using System.Text.RegularExpressions;
using Domain.Contracts;
using Domain.Contracts.Repository;
using Domain.Contracts.Services;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : Entity
{
    public PersonName Name { get; set; }
    public EmailAddress Email { get; set; }
    public string? HashedPassword { get; set; }
    public DateTime? EmailVerifiedAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User(PersonName name, EmailAddress email)
    {
        Name = name;
        Email = email;
    }

    public void SetHashedPasswordFromPlainText(IStringHashingService stringHashingService, string password)
    {
        ValidatePasswordContent(password);
        HashedPassword = stringHashingService.GetPasswordHash(password);
    }

    public void ValidatePasswordContent(string password)
    {
        if (password.Length < 5 || password.Length > 30)
            throw new DomainException("A senha de usuário deve conter entre 5 e 30 caracteres.");

        if (password.ToCharArray().Contains(' '))
            throw new DomainException("A senha de usuário não pode conter espaços.");

        if (!Regex.IsMatch(password, @"(.*\d.*)"))
            throw new DomainException("A senha de usuário deve conter algum número.");

        if (!Regex.IsMatch(password, "(.*[a-z].*)"))
            throw new DomainException("A senha de usuário deve conter alguma letra minúscula.");

        if (!Regex.IsMatch(password, "(.*[A-Z].*)"))
            throw new DomainException("A senha de usuário deve conter alguma letra maiúscula.");

        if (!Regex.IsMatch(password, @"(.*[!@#$%&*+\-_=~^?].*)"))
            throw new DomainException("A senha de usuário deve conter algum símbolo válido (! @ # $ % & * + - _ = ~ ^ ?).");

        if (Regex.Replace(password, @".*([!@#$%&*+\-_=~^?\w]).*", "").Length > 0)
            throw new DomainException("A senha de usuário só pode conter símbolos válidos (! @ # $ % & * + - _ = ~ ^ ?) e nenhum outro.");
    }

    public bool IsPasswordCorrect(IStringHashingService stringHashingService, string password)
    {
        if (HashedPassword is null)
            throw new Exception("Não há como comparar a senha com uma hash indefinida.");

        return stringHashingService.CheckPasswordHashMatches(password, HashedPassword);
    }

    public bool IsEmailAddressAlreadyInUse(IUserQueriesRepository repository, EmailAddress emailAddress)
    {
        var user = repository.findByEmail(emailAddress);
        return user != null;
    }

}
