using EFManager.API.Domain.Fitness;
using System;

namespace EFManager.API.Application.Fitness.TrainingSessions;

public class UpdateTrainingSessionRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime? EndSession { get; set; }
    public bool? IsPrivate { get; set; }
    public Guid? TrainingPlanId { get; set; }
    public IList<TrainingSessionRecordDto> TrainingSessionRecords { get; set; } = new List<TrainingSessionRecordDto>();
}

public class UpdateTrainingSessionRequestHandler : IRequestHandler<UpdateTrainingSessionRequest, Guid>
{
    private readonly IRepositoryWithEvents<TrainingSession> _repository;
    private readonly IStringLocalizer _t;

    public UpdateTrainingSessionRequestHandler(IRepositoryWithEvents<TrainingSession> repository, IStringLocalizer<UpdateTrainingSessionRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(UpdateTrainingSessionRequest request, CancellationToken cancellationToken)
    {
        var trainingSession = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = trainingSession
        ?? throw new NotFoundException(_t["Training Session {0} Not Found.", request.Id]);

        trainingSession.Update(request.Name, request.EndSession, null, request.IsPrivate, request.TrainingPlanId);

        foreach (var recordDto in request.TrainingSessionRecords)
        {
            var record = trainingSession.TrainingSessionRecords.FirstOrDefault(r => r.Id == recordDto.Id);
            if (record != null)
            {
                record.Update(recordDto.Name, recordDto.Set, recordDto.Repetition, recordDto.Weight, recordDto.ToFailure, recordDto.IsPrivate, trainingSession.Id);
            }
        }

        await _repository.UpdateAsync(trainingSession, cancellationToken);

        return request.Id;
    }
}
