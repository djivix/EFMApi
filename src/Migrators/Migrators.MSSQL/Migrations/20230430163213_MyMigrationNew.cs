using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class MyMigrationNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessExercises_TrainingPlans_TrainingPlanId",
                schema: "Catalog",
                table: "FitnessExercises");

            migrationBuilder.DropIndex(
                name: "IX_FitnessExercises_TrainingPlanId",
                schema: "Catalog",
                table: "FitnessExercises");

            migrationBuilder.DropColumn(
                name: "TrainingPlanId",
                schema: "Catalog",
                table: "FitnessExercises");

            migrationBuilder.CreateTable(
                name: "TrainingPlanFitnessExercises",
                schema: "Catalog",
                columns: table => new
                {
                    TrainingPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FitnessExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanFitnessExercises", x => new { x.TrainingPlanId, x.FitnessExerciseId });
                    table.ForeignKey(
                        name: "FK_TrainingPlanFitnessExercises_FitnessExercises_FitnessExerciseId",
                        column: x => x.FitnessExerciseId,
                        principalSchema: "Catalog",
                        principalTable: "FitnessExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanFitnessExercises_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalSchema: "Catalog",
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanFitnessExercises_FitnessExerciseId",
                schema: "Catalog",
                table: "TrainingPlanFitnessExercises",
                column: "FitnessExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanFitnessExercises",
                schema: "Catalog");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingPlanId",
                schema: "Catalog",
                table: "FitnessExercises",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessExercises_TrainingPlanId",
                schema: "Catalog",
                table: "FitnessExercises",
                column: "TrainingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessExercises_TrainingPlans_TrainingPlanId",
                schema: "Catalog",
                table: "FitnessExercises",
                column: "TrainingPlanId",
                principalSchema: "Catalog",
                principalTable: "TrainingPlans",
                principalColumn: "Id");
        }
    }
}
