using Microsoft.EntityFrameworkCore;
using MoodDiaryFierce.Database;
using MoodDiaryFierce.Models.Databases;

namespace MoodDiaryFierce.Services;
[ActivatorUtilitiesConstructor]
public class UserManagerService(
    IHttpContextAccessor contextAccessor,
    DatabaseContext dataContext)
{
    public async Task<List<MoodModel>> GetMoodsAsync()
    {
        var username = contextAccessor!.HttpContext!.User.Identity!.Name!;
        var user = await dataContext.Users
            .Include(u => u.Moods)
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user is null)
            return new List<MoodModel>();
        return user.Moods.OrderByDescending(m => m.Time).ToList();
    }
    public async Task EditMoodAsync(MoodModel updatedMood)
    {
        var username = contextAccessor!.HttpContext!.User.Identity!.Name!;
        var mood = await dataContext.Moods.FirstOrDefaultAsync(u =>
            u.User!.Username == username &&
            u.Id == updatedMood.Id);

        if (mood is not null)
        {
            dataContext.Moods.Update(updatedMood);
            await dataContext.SaveChangesAsync();
        }
    }
    public async Task DeleteMoodAsync(MoodModel deletedMood)
    {
        var username = contextAccessor!.HttpContext!.User.Identity!.Name!;
        var mood = await dataContext.Moods.FirstOrDefaultAsync(u =>
            u.User!.Username == username &&
            u.Id == deletedMood.Id);

        if (mood is not null)
        {
            dataContext.Moods.Remove(deletedMood);
            await dataContext.SaveChangesAsync();
        }
    }
    public async Task AddMoodAsync(MoodModel mood)
    {
        var username = contextAccessor!.HttpContext!.User.Identity!.Name!;
        var user = await dataContext.Users
            .Include(u => u.Moods)
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user is not null)
        {
            user.Moods.Add(mood);
            await dataContext.SaveChangesAsync();
        }
    }
}
