using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodDiaryFierce.Models.Databases;

public class MoodModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required DateTime Time { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    [ForeignKey(nameof(UserId))]
    public UserModel? User { get; set; }
    public int Happiness { get; set; } = 0;
    public int Sadness { get; set; } = 0;
    public int Fear { get; set; } = 0;
    public int Disgust { get; set; } = 0;
    public int Anger { get; set; } = 0;
    public int Surprise { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
}
