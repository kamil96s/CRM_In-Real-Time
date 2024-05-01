using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CRMServicesDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "CRMs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CRMs_DeletedById",
                table: "CRMs",
                column: "DeletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CRMs_AspNetUsers_DeletedById",
                table: "CRMs",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CRMs_AspNetUsers_DeletedById",
                table: "CRMs");

            migrationBuilder.DropIndex(
                name: "IX_CRMs_DeletedById",
                table: "CRMs");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "CRMs");
        }
    }
}
