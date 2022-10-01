using recetas2.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetas2.datos.Interfaces
{
    public interface IRecetaDao
    {
        int ObtenerProximoID();
        List<Ingrediente> ToGetIngredientes();
        bool Save(Receta nuevo);
    }
}
