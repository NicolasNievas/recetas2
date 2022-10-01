using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetas2.dominio
{
    public class Ingrediente
    {
        public int IngredienteID { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public Ingrediente(int ingredienteId, string nombre, string unidadMedida)
        {
            IngredienteID = ingredienteId;
            Nombre = nombre;
            UnidadMedida = unidadMedida;
        }
        public Ingrediente()
        {
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
