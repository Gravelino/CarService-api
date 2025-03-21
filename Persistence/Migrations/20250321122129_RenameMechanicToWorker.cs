using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameMechanicToWorker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicServices_Mechanics_MechanicId",
                table: "MechanicServices");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitServiceSchedules_Mechanics_MechanicId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Tools");

            migrationBuilder.RenameColumn(
                name: "MechanicId",
                table: "VisitServiceSchedules",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitServiceSchedules_MechanicId",
                table: "VisitServiceSchedules",
                newName: "IX_VisitServiceSchedules_WorkerId");

            migrationBuilder.RenameColumn(
                name: "MechanicId",
                table: "MechanicServices",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_MechanicServices_MechanicId",
                table: "MechanicServices",
                newName: "IX_MechanicServices_WorkerId");

            migrationBuilder.RenameColumn(
                name: "IsBooked",
                table: "Mechanics",
                newName: "IsActive");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicServices_Mechanics_WorkerId",
                table: "MechanicServices",
                column: "WorkerId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServiceSchedules_Mechanics_WorkerId",
                table: "VisitServiceSchedules",
                column: "WorkerId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicServices_Mechanics_WorkerId",
                table: "MechanicServices");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitServiceSchedules_Mechanics_WorkerId",
                table: "VisitServiceSchedules");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "VisitServiceSchedules",
                newName: "MechanicId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitServiceSchedules_WorkerId",
                table: "VisitServiceSchedules",
                newName: "IX_VisitServiceSchedules_MechanicId");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "MechanicServices",
                newName: "MechanicId");

            migrationBuilder.RenameIndex(
                name: "IX_MechanicServices_WorkerId",
                table: "MechanicServices",
                newName: "IX_MechanicServices_MechanicId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Mechanics",
                newName: "IsBooked");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Tools",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicServices_Mechanics_MechanicId",
                table: "MechanicServices",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServiceSchedules_Mechanics_MechanicId",
                table: "VisitServiceSchedules",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
