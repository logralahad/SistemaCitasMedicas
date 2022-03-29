using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCitasMedicas.Data.Migrations
{
    public partial class IS2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Empleados",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Empleados");
        }
    }
}
