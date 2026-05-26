#nullable disable

namespace Practical24.DAL.Migrations;

/// <inheritdoc />
public partial class InitialOvertimeMigrations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                DepartmentId = table.Column<int>(type: "int", nullable: false),
                EmailId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Employees");
    }
}
