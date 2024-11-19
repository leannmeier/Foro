using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Models{
    public class Categoria{
        public int CategoriaId{ get; set; }
        public string Nombre { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
        

    }
}
