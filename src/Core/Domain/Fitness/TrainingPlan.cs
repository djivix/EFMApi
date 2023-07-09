namespace EFManager.API.Domain.Fitness;
public class TrainingPlan : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public bool IsPrivate { get; private set; } = true;

    // Add this navigation property
    public ICollection<TrainingPlanFitnessExercise> TrainingPlanFitnessExercises { get; private set; } = new List<TrainingPlanFitnessExercise>();

    public TrainingPlan(string name, bool isPrivate)
    {
        Name = name;
        IsPrivate = isPrivate;

    }

    public TrainingPlan Update(string? name, bool? isPrivate)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (isPrivate.HasValue && IsPrivate != isPrivate.Value) IsPrivate = isPrivate.Value;

        return this;
    }
}

