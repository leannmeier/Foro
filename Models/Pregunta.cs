using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Models{
    public class Pregunta  {
        public int PreguntaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        [Display(Name = "Likes")]
        public int CantMeGustas { get; set; }
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
        public ICollection<Categoria> Categorias { get; set; }

        


    }
}
