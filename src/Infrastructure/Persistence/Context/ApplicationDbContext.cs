using Finbuckle.MultiTenant;
using EFManager.API.Application.Common.Events;
using EFManager.API.Application.Common.Interfaces;
using EFManager.API.Domain.Catalog;
using EFManager.API.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EFManager.API.Domain.Fitness;

namespace EFManager.API.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<FitnessExercise> FitnessExercises => Set<FitnessExercise>();
    public DbSet<TrainingPlan> TrainingPlans => Set<TrainingPlan>();
    public DbSet<TrainingSession> TrainingSessions => Set<TrainingSession>();
    public DbSet<TrainingPlanFitnessExercise> TrainingPlanFitnessExercises => Set<TrainingPlanFitnessExercise>();
    public DbSet<TrainingSessionRecord> TrainingSessionRecords => Set<TrainingSessionRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);

        modelBuilder.Entity<TrainingPlanFitnessExercise>(entity =>
        {
            entity.HasKey(e => new { e.TrainingPlanId, e.FitnessExerciseId, e.Order }); // Updated composite primary key

            entity.HasOne(e => e.TrainingPlan)
                .WithMany(t => t.TrainingPlanFitnessExercises)
                .HasForeignKey(e => e.TrainingPlanId);

            entity.HasOne(e => e.FitnessExercise)
                .WithMany(f => f.TrainingPlanFitnessExercises)
                .HasForeignKey(e => e.FitnessExerciseId);
        });
    }

}