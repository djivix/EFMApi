using EFManager.API.Application.Fitness.Exercises;

namespace EFManager.API.Host.Controllers.Fitness;

public class TrainingPlanController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TrainingPlans)]
    [OpenApiOperation("Create a new trainingplan.", "")]
    public Task<Guid> CreateAsync(CreateTrainingPlanRequest request)
    {
        return Mediator.Send(request);
    }
}

