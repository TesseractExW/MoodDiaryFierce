using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace MoodDiaryFierce.Models.Databases;

public class UserModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    [InverseProperty(nameof(MoodModel.User))]
    public List<MoodModel> Moods { get; set; } = new List<MoodModel>();
    public ClaimsPrincipal GetPrincipal()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Username),
            new Claim(ClaimTypes.Role, Constants.Admins.Contains(Username) ? "Admin" : "User"),
        };
        var identity = new ClaimsIdentity(claims, Constants.AuthScheme);
        return new ClaimsPrincipal(identity);
    }
}
