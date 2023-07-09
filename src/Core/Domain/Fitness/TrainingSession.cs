using EFManager.API.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFManager.API.Domain.Fitness;

public class TrainingSession : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public DateTime StartSession { get; private set; }
    public DateTime EndSessionSession { get; private set; }
    public bool IsPrivate { get; private set; } = true;
    public Guid TrainingPlanId { get; private set; }
    public virtual TrainingPlan TrainingPlan { get; private set; } = default!;
    public virtual ICollection<TrainingSessionRecord> TrainingSessionRecords { get; private set; } = new List<TrainingSessionRecord>();

    protected TrainingSession()
    {
    }

    public TrainingSession(string name, DateTime startSession, DateTime endSession, bool isPrivate, Guid trainingPlanId)
    {
        Name = name;
        StartSession = startSession;
        EndSessionSession = endSession;
        IsPrivate = isPrivate;
        TrainingPlanId = trainingPlanId;
    }

    public TrainingSession Update(string? name, DateTime? startSession, DateTime? endSession, bool? isPrivate, Guid? trainingPlanId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (startSession.HasValue && StartSession != startSession) StartSession = startSession.Value;
        if (endSession.HasValue && EndSessionSession != endSession) EndSessionSession = endSession.Value;
        if (isPrivate.HasValue && IsPrivate != isPrivate.Value) IsPrivate = isPrivate.Value;
        if (trainingPlanId.HasValue && trainingPlanId.Value != Guid.Empty && !trainingPlanId.Equals(trainingPlanId.Value)) TrainingPlanId = trainingPlanId.Value;

        return this;
    }
}

