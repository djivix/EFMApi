using EFManager.API.Domain.Common.Events;
using EFManager.API.Domain.Fitness;

public class CreateTrainingPlanRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public bool IsPrivate { get; set; }
    public List<Guid> FitnessExerciseIds { get; set; } = new List<Guid>();
}

public class CreateTrainingPlanRequestHandler : IRequestHandler<CreateTrainingPlanRequest, Guid>
{
    private readonly IRepository<TrainingPlan> _repository;

    public CreateTrainingPlanRequestHandler(IRepository<TrainingPlan> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateTrainingPlanRequest request, CancellationToken cancellationToken)
    {
        var trainingPlan = new TrainingPlan(request.Name, request.IsPrivate);

        // Add the FitnessExercises to the TrainingPlan using only the IDs and Order
        for (int i = 0; i < request.FitnessExerciseIds.Count; i++)
        {
            trainingPlan.TrainingPlanFitnessExercises.Add(new TrainingPlanFitnessExercise
            {
                TrainingPlanId = trainingPlan.Id,
                FitnessExerciseId = request.FitnessExerciseIds[i],
                Order = i
            });
        }

        // Add Domain Events to be raised after the commit
        trainingPlan.DomainEvents.Add(EntityCreatedEvent.WithEntity(trainingPlan));

        await _repository.AddAsync(trainingPlan, cancellationToken);

        return trainingPlan.Id;
    }
}