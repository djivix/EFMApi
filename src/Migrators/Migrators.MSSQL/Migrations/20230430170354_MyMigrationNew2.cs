using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class MyMigrationNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlanFitnessExercises",
                schema: "Catalog",
                table: "TrainingPlanFitnessExercises");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "Catalog",
                table: "TrainingPlanFitnessExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlanFitnessExercises",
                schema: "Catalog",
                table: "TrainingPlanFitnessExercises",
                columns: new[] { "TrainingPlanId", "FitnessExerciseId", "Order" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlanFitnessExercises",
                schema: "Catalog",
                table: "TrainingPlanFitnessExercises");

            migrationBuilder.DropColumn(
                name: "Order",
                schema: "Catalog",
                table: "TrainingPlanFitnessExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlanFitnessExercises",
                schema: "Catalog",
                table: "TrainingPlanFitnessExercises",
                columns: new[] { "TrainingPlanId", "FitnessExerciseId" });
        }
    }
}
