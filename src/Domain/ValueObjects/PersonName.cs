using Domain.Contracts;

namespace Domain.ValueObjects;

public class PersonName : IValueObject
{
    private const int MaxNameLength = 40;
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string FullName { get; init; }

    public PersonName(string firstName, string? lastName)
    {
        firstName = firstName.Trim();
        lastName = lastName?.Trim() ?? "";

        if (firstName.Length == 0)
            throw new Exception("First name cannot be empty.");

        if (firstName.Length > MaxNameLength)
            throw new Exception($"First name cannot be longer than {MaxNameLength} characters.");

        FirstName = firstName;
        LastName = lastName;
        FullName = lastName.Length > 0 ? $"{firstName} {lastName}" : firstName;
    }

    public Dictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>()
        {
            { "firstName", FirstName },
            { "lastName", LastName },
            { "fullName", FullName }
        };
    }

}
