using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removingunecessaryfk2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COD_USER_INFO",
                table: "TB_USER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "COD_USER_INFO",
                table: "TB_USER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
