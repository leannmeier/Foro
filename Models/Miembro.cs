using System.Diagnostics.CodeAnalysis;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Models{
    public class Miembro : Usuario {
        public int MiembroId { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }

        public string NombreCompleto{
            get { return Nombre + " " + Apellido; }
        }

    }
}
