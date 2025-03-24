using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ToolServiceRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitServiceSchedules_Visits_VisitId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropTable(
                name: "ServiceTools");

            migrationBuilder.DropIndex(
                name: "IX_VisitServiceSchedules_VisitId",
                table: "VisitServiceSchedules");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "VisitServiceSchedules");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Services",
                newName: "ServiceCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                newName: "IX_Services_ServiceCategoryId");

            migrationBuilder.CreateTable(
                name: "ServiceTool",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "integer", nullable: false),
                    ToolsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTool", x => new { x.ServicesId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_ServiceTool_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTool_Tools_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTool_ToolsId",
                table: "ServiceTool",
                column: "ToolsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceCategories_ServiceCategoryId",
                table: "Services",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceCategories_ServiceCategoryId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceTool");

            migrationBuilder.RenameColumn(
                name: "ServiceCategoryId",
                table: "Services",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceCategoryId",
                table: "Services",
                newName: "IX_Services_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "VisitServiceSchedules",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceTools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    ToolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTools_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTools_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitServiceSchedules_VisitId",
                table: "VisitServiceSchedules",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTools_ServiceId",
                table: "ServiceTools",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTools_ToolId",
                table: "ServiceTools",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServiceSchedules_Visits_VisitId",
                table: "VisitServiceSchedules",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");
        }
    }
}
