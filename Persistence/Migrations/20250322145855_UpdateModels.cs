using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "VisitServiceSchedules",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Payments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Feedbacks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitServiceSchedules_VisitId",
                table: "VisitServiceSchedules",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServiceSchedules_Visits_VisitId",
                table: "VisitServiceSchedules",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServiceSchedules_Visits_VisitId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_VisitServiceSchedules_VisitId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Feedbacks");
        }
    }
}
