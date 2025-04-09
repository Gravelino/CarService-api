using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class JobSoftDeletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobSchedules_JobId",
                table: "JobSchedules");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Jobs",
                newName: "JobScheduleId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ServiceCategories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSchedules_JobId",
                table: "JobSchedules",
                column: "JobId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobSchedules_JobId",
                table: "JobSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ServiceCategories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "JobScheduleId",
                table: "Jobs",
                newName: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_JobSchedules_JobId",
                table: "JobSchedules",
                column: "JobId");
        }
    }
}
