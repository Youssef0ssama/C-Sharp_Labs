using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIEntities.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsDeptID",
                table: "CourseDepartment");

            migrationBuilder.RenameColumn(
                name: "DeptID",
                table: "Departments",
                newName: "DeptId");

            migrationBuilder.RenameColumn(
                name: "DepartmentsDeptID",
                table: "CourseDepartment",
                newName: "DepartmentsDeptId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentsDeptID",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentsDeptId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsDeptId",
                table: "CourseDepartment",
                column: "DepartmentsDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsDeptId",
                table: "CourseDepartment");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Departments",
                newName: "DeptID");

            migrationBuilder.RenameColumn(
                name: "DepartmentsDeptId",
                table: "CourseDepartment",
                newName: "DepartmentsDeptID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentsDeptId",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentsDeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsDeptID",
                table: "CourseDepartment",
                column: "DepartmentsDeptID",
                principalTable: "Departments",
                principalColumn: "DeptID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
