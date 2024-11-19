using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Migrations
{
    public partial class cascadeRespuestas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuestas_Pregunta_PreguntaId",
                table: "Respuestas");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuestas_Pregunta_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId",
                principalTable: "Pregunta",
                principalColumn: "PreguntaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuestas_Pregunta_PreguntaId",
                table: "Respuestas");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuestas_Pregunta_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId",
                principalTable: "Pregunta",
                principalColumn: "PreguntaId");
        }
    }
}
