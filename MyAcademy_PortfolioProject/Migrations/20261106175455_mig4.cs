using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademy_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        IF EXISTS (
            SELECT 1
            FROM sys.indexes
            WHERE name = 'IX_Projects_CategoryID'
              AND object_id = OBJECT_ID('dbo.Projects')
        )
        DROP INDEX [IX_Projects_CategoryID] ON [dbo].[Projects];
    ");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryID",
                table: "Projects",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_CategoryID",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryID",
                table: "Projects",
                column: "CategoryID",
                unique: true);
        }
    }
}
