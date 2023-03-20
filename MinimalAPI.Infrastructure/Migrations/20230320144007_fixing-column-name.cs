using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixingcolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USER_INFO_TB_USER_COD_USER_ENTITY",
                table: "TB_USER_INFO");

            migrationBuilder.RenameColumn(
                name: "COD_USER_ENTITY",
                table: "TB_USER_INFO",
                newName: "COD_USER");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USER_INFO_COD_USER_ENTITY",
                table: "TB_USER_INFO",
                newName: "IX_TB_USER_INFO_COD_USER");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USER_INFO_TB_USER_COD_USER",
                table: "TB_USER_INFO",
                column: "COD_USER",
                principalTable: "TB_USER",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USER_INFO_TB_USER_COD_USER",
                table: "TB_USER_INFO");

            migrationBuilder.RenameColumn(
                name: "COD_USER",
                table: "TB_USER_INFO",
                newName: "COD_USER_ENTITY");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USER_INFO_COD_USER",
                table: "TB_USER_INFO",
                newName: "IX_TB_USER_INFO_COD_USER_ENTITY");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USER_INFO_TB_USER_COD_USER_ENTITY",
                table: "TB_USER_INFO",
                column: "COD_USER_ENTITY",
                principalTable: "TB_USER",
                principalColumn: "Id");
        }
    }
}
