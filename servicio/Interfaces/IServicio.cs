using recetas2.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetas2.servicio.Interfaces
{
    public interface IServicio
    {
        int ProximaReceta();
        List<Ingrediente> ObtenerIngredientes();
        bool ConfirmarReceta(Receta nuevo);
    }
}
