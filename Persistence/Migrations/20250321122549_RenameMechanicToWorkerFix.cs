using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameMechanicToWorkerFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicServices_Mechanics_WorkerId",
                table: "MechanicServices");

            migrationBuilder.DropForeignKey(
                name: "FK_MechanicServices_Services_ServiceId",
                table: "MechanicServices");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitServiceSchedules_Mechanics_WorkerId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MechanicServices",
                table: "MechanicServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mechanics",
                table: "Mechanics");

            migrationBuilder.RenameTable(
                name: "MechanicServices",
                newName: "WorkerServices");

            migrationBuilder.RenameTable(
                name: "Mechanics",
                newName: "Worker");

            migrationBuilder.RenameIndex(
                name: "IX_MechanicServices_WorkerId",
                table: "WorkerServices",
                newName: "IX_WorkerServices_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_MechanicServices_ServiceId",
                table: "WorkerServices",
                newName: "IX_WorkerServices_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerServices",
                table: "WorkerServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                table: "Worker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServiceSchedules_Worker_WorkerId",
                table: "VisitServiceSchedules",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerServices_Services_ServiceId",
                table: "WorkerServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerServices_Worker_WorkerId",
                table: "WorkerServices",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServiceSchedules_Worker_WorkerId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerServices_Services_ServiceId",
                table: "WorkerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerServices_Worker_WorkerId",
                table: "WorkerServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerServices",
                table: "WorkerServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                table: "Worker");

            migrationBuilder.RenameTable(
                name: "WorkerServices",
                newName: "MechanicServices");

            migrationBuilder.RenameTable(
                name: "Worker",
                newName: "Mechanics");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerServices_WorkerId",
                table: "MechanicServices",
                newName: "IX_MechanicServices_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerServices_ServiceId",
                table: "MechanicServices",
                newName: "IX_MechanicServices_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MechanicServices",
                table: "MechanicServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mechanics",
                table: "Mechanics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicServices_Mechanics_WorkerId",
                table: "MechanicServices",
                column: "WorkerId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicServices_Services_ServiceId",
                table: "MechanicServices",
                column: "ServiceId",
                principalTable: "Services",
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
    }
}
