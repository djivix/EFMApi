using EFManager.API.Application.Catalog.Brands;
using EFManager.API.Application.Fitness.Exercises;
using EFManager.API.Domain.Fitness;

namespace EFManager.API.Application.Fitness;

public class CreateFitnessExerciseRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string? Force { get; set; }
    public string? Category { get; set; }
    public string? GymName { get; set; }
    public string? Equipment { get; set; }
    public string? Target { get; set; }
    public bool IsPrivate { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public string? VideoPath { get; set; }
}

public class CreateFitnessExerciseRequestValidator : CustomValidator<CreateFitnessExerciseRequest>
{
    public CreateFitnessExerciseRequestValidator(IReadRepository<FitnessExercise> repository)
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(async (name, ct) => await repository.FirstOrDefaultAsync(new FitnessExerciseByNameSpec(name), ct) is null)
            .WithMessage("Fitness Exercise with the same name already exists.");
    }
}

public class CreateFitnessExerciseRequestHandler : IRequestHandler<CreateFitnessExerciseRequest, Guid>
{
    private readonly IRepositoryWithEvents<FitnessExercise> _repository;

    public CreateFitnessExerciseRequestHandler(IRepositoryWithEvents<FitnessExercise> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateFitnessExerciseRequest request, CancellationToken cancellationToken)
    {
        var fitnessExercise = new FitnessExercise(request.Name, request.Force, request.Category, request.GymName, request.Equipment, request.Target, request.IsPrivate, request.Description, request.ImagePath, request.VideoPath);

        await _repository.AddAsync(fitnessExercise, cancellationToken);

        return fitnessExercise.Id;
    }
}
