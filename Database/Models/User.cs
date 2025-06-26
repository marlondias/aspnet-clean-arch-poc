using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CleanArchPOC.Database.Models;

[Table("users")]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }

    [Column("first_name")]
    [MaxLength(50)]
    public required string FirstName { get; set; }

    [Column("last_name")]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Column("email")]
    [MaxLength(255)]
    public required string Email { get; set; }

    [Column("password")]
    public required string Password { get; set; }

    [Column("email_verified_at")]
    public DateTime? EmailVerifiedAt { get; set; }

    [Column("created_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}
