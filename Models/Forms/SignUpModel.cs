using System.ComponentModel.DataAnnotations;

namespace MoodDiaryFierce.Models.Forms;

public class SignUpModel : SignInModel
{
    [Compare(nameof(Password), ErrorMessage = "The password is not matched.")]
    public string ConfirmedPassword { get; set; } = string.Empty;
}
