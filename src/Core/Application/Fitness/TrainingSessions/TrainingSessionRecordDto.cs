namespace EFManager.API.Application.Fitness.TrainingSessions;

public class TrainingSessionRecordDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int? Set { get; set; }
    public int? Repetition { get; set; }
    public float? Weight { get; set; }
    public bool ToFailure { get; set; }
    public bool IsPrivate { get; set; } = true;
}