namespace CleanArchPOC.Adapters.Http.Controllers;

public class CreateUserRequestDTO
{
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;
    public string emailAddress { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
}

public class UpdateUserRequestDTO
{
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? emailAddress { get; set; }
    public string? password { get; set; }
}

public class CreateUserResponseDto
{
    public int id { get; set; }    
    public DateTime? createdAt { get; set; }
}


public class GetUserResponseDto
{
    public int id { get; set; }
    public string firstName { get; set; } = string.Empty;
    public string? lastName { get; set; }
    public string emailAddress { get; set; } = string.Empty;
    public DateTime? emailVerifiedAt { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
}

