namespace EFManager.API.Domain.Fitness;
public class TrainingPlanFitnessExercise
{
    public Guid TrainingPlanId { get; set; }
    public TrainingPlan TrainingPlan { get; set; }
    public Guid FitnessExerciseId { get; set; }
    public FitnessExercise FitnessExercise { get; set; }
    public int Order { get; set; }
}


