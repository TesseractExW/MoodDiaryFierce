using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MoodDiaryFierce.Models.Forms;

public class SignInModel
{
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(6, ErrorMessage = "Username must be at least 6 characters.")]
    [MaxLength(20, ErrorMessage = "Username must be at most 20 characters.")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
    [MaxLength(20, ErrorMessage = "Password must be at most 20 characters.")]
    public string Password { get; set; } = string.Empty;
}
