using EFManager.API.Domain.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFManager.API.Application.Fitness.TrainingSessions;
public class CreateTrainingSessionRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public bool IsPrivate { get; set; } = true;
    public Guid TrainingPlanId { get; set; }

    // Define a list of records to be created for the training session
    public IList<TrainingSessionRecordDto> TrainingSessionRecords { get; set; } = new List<TrainingSessionRecordDto>();
}

public class CreateTrainingSessionRequestHandler : IRequestHandler<CreateTrainingSessionRequest, Guid>
{
    private readonly IRepositoryWithEvents<TrainingSession> _repository;

    public CreateTrainingSessionRequestHandler(IRepositoryWithEvents<TrainingSession> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateTrainingSessionRequest request, CancellationToken cancellationToken)
    {
        // Set the current time as StartSession when the handler is executed
        var startTime = DateTime.Now;

        var trainingSession = new TrainingSession(request.Name, startTime, startTime, request.IsPrivate, request.TrainingPlanId);

        foreach (var recordDto in request.TrainingSessionRecords)
        {
            var record = new TrainingSessionRecord("Dummy", 0, 0, 0, false, true, trainingSession.Id);
            trainingSession.TrainingSessionRecords.Add(record);
        }

        await _repository.AddAsync(trainingSession, cancellationToken);

        return trainingSession.Id;
    }
}
