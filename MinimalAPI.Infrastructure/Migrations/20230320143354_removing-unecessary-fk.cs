using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removingunecessaryfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USER_TB_USER_INFO_COD_USER_INFO",
                table: "TB_USER");

            migrationBuilder.DropIndex(
                name: "IX_TB_USER_COD_USER_INFO",
                table: "TB_USER");

            migrationBuilder.AlterColumn<string>(
                name: "COD_USER_ENTITY",
                table: "TB_USER_INFO",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "COD_USER_INFO",
                table: "TB_USER",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_INFO_COD_USER_ENTITY",
                table: "TB_USER_INFO",
                column: "COD_USER_ENTITY",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USER_INFO_TB_USER_COD_USER_ENTITY",
                table: "TB_USER_INFO",
                column: "COD_USER_ENTITY",
                principalTable: "TB_USER",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USER_INFO_TB_USER_COD_USER_ENTITY",
                table: "TB_USER_INFO");

            migrationBuilder.DropIndex(
                name: "IX_TB_USER_INFO_COD_USER_ENTITY",
                table: "TB_USER_INFO");

            migrationBuilder.AlterColumn<string>(
                name: "COD_USER_ENTITY",
                table: "TB_USER_INFO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "COD_USER_INFO",
                table: "TB_USER",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_COD_USER_INFO",
                table: "TB_USER",
                column: "COD_USER_INFO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USER_TB_USER_INFO_COD_USER_INFO",
                table: "TB_USER",
                column: "COD_USER_INFO",
                principalTable: "TB_USER_INFO",
                principalColumn: "ID");
        }
    }
}
