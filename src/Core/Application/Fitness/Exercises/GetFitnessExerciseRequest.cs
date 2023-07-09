using EFManager.API.Application.Catalog.Brands;
using EFManager.API.Domain.Fitness;

namespace EFManager.API.Application.Fitness.Exercises;
public class GetFitnessExerciseRequest : IRequest<FitnessExerciseDto>
{
    public Guid Id { get; set; }
    public GetFitnessExerciseRequest(Guid id) => Id = id;
}

public class FitnessExerciseByIdSpec : Specification<FitnessExercise, FitnessExerciseDto>, ISingleResultSpecification
{
    public FitnessExerciseByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);

}

public class GetFitnessExerciseRequestHandler : IRequestHandler<GetFitnessExerciseRequest, FitnessExerciseDto>
{
    private readonly IRepository<FitnessExercise> _repository;
    private readonly IStringLocalizer _t;

    public GetFitnessExerciseRequestHandler(IRepository<FitnessExercise> repository, IStringLocalizer<GetFitnessExerciseRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<FitnessExerciseDto> Handle(GetFitnessExerciseRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<FitnessExercise, FitnessExerciseDto>)new FitnessExerciseByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Exercise {0} Not Found.", request.Id]);
}