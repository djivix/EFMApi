namespace EFManager.API.Domain.Fitness;

public class FitnessExercise : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public string? Force { get; private set; }
    public string? Category { get; private set; }
    public string? GymName { get; private set; }
    public string? Equipment { get; private set; }
    public string? Target { get; private set; }
    public bool IsPrivate { get; private set; }
    public string? Description { get; private set; }
    public string? ImagePath { get; private set; }
    public string? VideoPath { get; private set; }

    // Add this navigation property
    public ICollection<TrainingPlanFitnessExercise> TrainingPlanFitnessExercises { get; private set; } = new List<TrainingPlanFitnessExercise>();

    public FitnessExercise(string name, string? force, string? category, string? gymName, string? equipment, string? target, bool isPrivate, string? description, string? imagePath, string? videoPath)
    {
        Name = name;
        Force = force;
        Category = category;
        GymName = gymName;
        Equipment = equipment;
        Target = target;
        IsPrivate = isPrivate;
        Description = description;
        ImagePath = imagePath;
        VideoPath = videoPath;
    }

    public FitnessExercise Update(string? name, string? force, string? category, string? gymName, string? equipment, string? target, bool? isPrivate, string? description, string? imagePath, string? videoPath)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (force is not null && Force?.Equals(force) is not true) Force = force;
        if (category is not null && Category?.Equals(category) is not true) Category = category;
        if (gymName is not null && GymName?.Equals(gymName) is not true) GymName = gymName;
        if (equipment is not null && Equipment?.Equals(equipment) is not true) Equipment = equipment;
        if (target is not null && Target?.Equals(target) is not true) Target = target;
        if (isPrivate.HasValue && IsPrivate != isPrivate.Value) IsPrivate = isPrivate.Value;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        if (videoPath is not null && VideoPath?.Equals(videoPath) is not true) VideoPath = videoPath;
        return this;
    }

    public FitnessExercise ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }

    public FitnessExercise ClearVideoPath()
    {
        VideoPath = string.Empty;
        return this;
    }

}
