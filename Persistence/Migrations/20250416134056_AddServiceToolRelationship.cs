using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceToolRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTools",
                table: "ServiceTools",
                columns: new[] { "ServicesId", "ToolsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTools_ToolsId",
                table: "ServiceTools",
                column: "ToolsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTools_Services_ServicesId",
                table: "ServiceTools",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTools_Tools_ToolsId",
                table: "ServiceTools",
                column: "ToolsId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTools_Services_ServicesId",
                table: "ServiceTools");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTools_Tools_ToolsId",
                table: "ServiceTools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTools",
                table: "ServiceTools");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTools_ToolsId",
                table: "ServiceTools");
        }
    }
}
