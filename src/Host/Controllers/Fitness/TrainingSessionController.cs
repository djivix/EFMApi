using EFManager.API.Application.Catalog.Brands;
using EFManager.API.Application.Fitness;
using EFManager.API.Application.Fitness.TrainingSessions;

namespace EFManager.API.Host.Controllers.Fitness;

public class TrainingSessionController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TrainingSessions)]
    [OpenApiOperation("Create a new TrainingSession.", "")]
    public Task<Guid> CreateAsync(CreateTrainingSessionRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TrainingSessions)]
    [OpenApiOperation("Update a TrainingSession.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTrainingSessionRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }
}