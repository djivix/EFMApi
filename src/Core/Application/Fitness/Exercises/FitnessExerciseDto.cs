namespace EFManager.API.Application.Fitness.Exercises;

public class FitnessExerciseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Force { get; set; }
    public string? Category { get; set; }
    public string? GymName { get; set; }
    public string? Equipment { get; set; }
    public string? Target { get; set; }
    public bool IsPrivate { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public string? VideoPath { get; set; }
}
