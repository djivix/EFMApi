using EFManager.API.Domain.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFManager.API.Application.Fitness.Exercises;
public class FitnessExerciseByNameSpec : Specification<FitnessExercise>, ISingleResultSpecification
{
    public FitnessExerciseByNameSpec(string name) =>
    Query.Where(b => b.Name == name);
}
