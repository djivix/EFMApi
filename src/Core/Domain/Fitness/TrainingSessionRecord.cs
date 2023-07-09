namespace EFManager.API.Domain.Fitness;
public class TrainingSessionRecord : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public int? Set { get; private set; }
    public int? Repetition { get; private set; }
    public float? Weight { get; private set; }
    public bool ToFailure { get; private set; }
    public bool IsPrivate { get; private set; } = true;
    public Guid TrainingSessionId { get; private set; }
    public virtual TrainingSession TrainingSession { get; private set; } = default!;
    public TrainingSessionRecord(string name, int? set, int? repetition, float? weight, bool toFailure, bool isPrivate, Guid trainingSessionId)
    {
        Name = name;
        Set = set;
        Repetition = repetition;
        Weight = weight;
        ToFailure = toFailure;
        IsPrivate = isPrivate;
        TrainingSessionId = trainingSessionId;
    }

    public TrainingSessionRecord Update(string? name, int? set, int? repetition, float? weight, bool? toFailure, bool? isPrivate, Guid? trainingSessionId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (set.HasValue && Set != set) Set = set.Value;
        if (repetition.HasValue && Repetition != repetition) Repetition = repetition.Value;
        if (weight.HasValue && Weight != weight) Weight = weight.Value;
        if (toFailure.HasValue && ToFailure != toFailure.Value) ToFailure = toFailure.Value;
        if (isPrivate.HasValue && IsPrivate != isPrivate.Value) IsPrivate = isPrivate.Value;
        if (trainingSessionId.HasValue && trainingSessionId.Value != Guid.Empty && !trainingSessionId.Equals(trainingSessionId.Value)) TrainingSessionId = trainingSessionId.Value;

        return this;
    }
}
