using System.ComponentModel.DataAnnotations;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Models{
    public class Respuesta {
        public int RespuestaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        [Display(Name = "Likes")]
        public int CantMeGustas { get; set; }
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }

    }
}
