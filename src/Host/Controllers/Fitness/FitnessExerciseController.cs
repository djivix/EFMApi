using EFManager.API.Application.Catalog.Brands;
using EFManager.API.Application.Fitness;
using EFManager.API.Application.Fitness.Exercises;

namespace EFManager.API.Host.Controllers.Fitness;

public class FitnessExerciseController : VersionedApiController
{
    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.FitnessExercises)]
    [OpenApiOperation("Get exercise details.", "")]
    public Task<FitnessExerciseDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetFitnessExerciseRequest(id));
    }

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.FitnessExercises)]
    [OpenApiOperation("Get all exercises.", "Retrieves a list of all fitness exercises.")]
    public Task<IEnumerable<FitnessExerciseDto>> GetAllAsync()
    {
        return Mediator.Send(new GetAllFitnessExercisesRequest());
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.FitnessExercises)]
    [OpenApiOperation("Create a new exercise.", "")]
    public Task<Guid> CreateAsync(CreateFitnessExerciseRequest request)
    {
        return Mediator.Send(request);
    }
}
