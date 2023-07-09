using EFManager.API.Domain.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFManager.API.Application.Fitness.Exercises;
public class GetAllFitnessExercisesRequest : IRequest<IEnumerable<FitnessExerciseDto>>
{
}

public class AllFitnessExercisesSpec : Specification<FitnessExercise, FitnessExerciseDto>
{
    public AllFitnessExercisesSpec() =>
        Query.OrderBy(p => p.Name);
}

public class GetAllFitnessExercisesRequestHandler : IRequestHandler<GetAllFitnessExercisesRequest, IEnumerable<FitnessExerciseDto>>
{
    private readonly IRepository<FitnessExercise> _repository;

    public GetAllFitnessExercisesRequestHandler(IRepository<FitnessExercise> repository) => _repository = repository;

    public async Task<IEnumerable<FitnessExerciseDto>> Handle(GetAllFitnessExercisesRequest request, CancellationToken cancellationToken) =>
        await _repository.ListAsync(new AllFitnessExercisesSpec(), cancellationToken);
}
