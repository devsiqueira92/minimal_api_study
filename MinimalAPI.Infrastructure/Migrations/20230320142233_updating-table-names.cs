using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatingtablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_TB_USER_UserEntityId",
                table: "UsersInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInfo",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_UserEntityId",
                table: "UsersInfo");

            migrationBuilder.RenameTable(
                name: "UsersInfo",
                newName: "TB_USER_INFO");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "TB_USER_INFO",
                newName: "COD_USER_ENTITY");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_USER_INFO",
                newName: "TXT_NAME");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "TB_USER_INFO",
                newName: "TXT_GENDER");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "TB_USER_INFO",
                newName: "DAT_BIRTHDATE");

            migrationBuilder.AlterColumn<string>(
                name: "COD_USER_INFO",
                table: "TB_USER",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "COD_USER_ENTITY",
                table: "TB_USER_INFO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_NAME",
                table: "TB_USER_INFO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TXT_GENDER",
                table: "TB_USER_INFO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DAT_BIRTHDATE",
                table: "TB_USER_INFO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USER_INFO",
                table: "TB_USER_INFO",
                column: "ID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USER_TB_USER_INFO_COD_USER_INFO",
                table: "TB_USER");

            migrationBuilder.DropIndex(
                name: "IX_TB_USER_COD_USER_INFO",
                table: "TB_USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USER_INFO",
                table: "TB_USER_INFO");

            migrationBuilder.RenameTable(
                name: "TB_USER_INFO",
                newName: "UsersInfo");

            migrationBuilder.RenameColumn(
                name: "TXT_NAME",
                table: "UsersInfo",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TXT_GENDER",
                table: "UsersInfo",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "DAT_BIRTHDATE",
                table: "UsersInfo",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "COD_USER_ENTITY",
                table: "UsersInfo",
                newName: "UserEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "COD_USER_INFO",
                table: "TB_USER",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserEntityId",
                table: "UsersInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInfo",
                table: "UsersInfo",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserEntityId",
                table: "UsersInfo",
                column: "UserEntityId",
                unique: true,
                filter: "[UserEntityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_TB_USER_UserEntityId",
                table: "UsersInfo",
                column: "UserEntityId",
                principalTable: "TB_USER",
                principalColumn: "Id");
        }
    }
}
