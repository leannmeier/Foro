using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Migrations
{
    public partial class PreguntaRemoveActiva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activa",
                table: "Pregunta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activa",
                table: "Pregunta",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
