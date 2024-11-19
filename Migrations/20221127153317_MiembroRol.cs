using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Migrations
{
    public partial class MiembroRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Miembros",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Miembros");
        }
    }
}
