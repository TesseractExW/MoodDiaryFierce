using Microsoft.EntityFrameworkCore;
using MoodDiaryFierce.Database;
using MoodDiaryFierce.Models.Forms;

namespace MoodDiaryFierce.Services;

using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using MoodDiaryFierce.Models.Databases;

public class FormAuthenticationService(
    IHttpContextAccessor contextAccessor,
    DatabaseContext dataContext)
{
    public async Task<string?> SignInAsync(SignInModel model)
    {
        if (contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true)
            return "Please sign out before sign in.";
        
        var user = await dataContext.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
        if (user is null)
            return "User does not exist.";
        if (!BCrypt.Verify(model.Password, user.Password))
            return "Password is not correct.";

        await contextAccessor?.HttpContext?.SignInAsync(user.GetPrincipal())!;
        return null;
    }
    public async Task<string?> SignOut()
    {
        if (contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true)
        {
            await contextAccessor?.HttpContext?.SignOutAsync(Constants.AuthScheme)!;
            return null;
        }
        else
        {
            return "Please sign in before sign out.";
        }
    }
    public async Task<string?> SignUpAsync(SignUpModel model)
    {
        if (contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true)
            return "Please sign out before sign up.";

        var user = await dataContext.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
        if (user is not null)
            return "User already exists.";

        UserModel userModel = new UserModel
        {
            Username = model.Username,
            Password = BCrypt.HashPassword(model.Password),
        };
        dataContext.Add(userModel);
        await dataContext.SaveChangesAsync();

        await contextAccessor?.HttpContext?.SignInAsync(userModel.GetPrincipal())!;
        return null;
    }
}
