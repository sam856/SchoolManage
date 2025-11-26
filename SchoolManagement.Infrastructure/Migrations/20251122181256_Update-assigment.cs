using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updateassigment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeByTeacherId",
                table: "Attendence");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Class_TeacherId",
                table: "Class",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_TeacherId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Class");

            migrationBuilder.AddColumn<int>(
                name: "GradeByTeacherId",
                table: "Attendence",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
