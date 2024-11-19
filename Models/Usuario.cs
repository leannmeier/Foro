using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Models
{
    public class Usuario{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de alta")]
        public DateTime FechaAlta { get; set; }
    }
}
