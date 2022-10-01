using recetas2.datos.Implementaciones;
using recetas2.datos.Interfaces;
using recetas2.dominio;
using recetas2.servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetas2.servicio.Implementaciones
{
    public class ServicioReceta : IServicio
    {
        private IRecetaDao dao;

        public ServicioReceta()
        {
            dao = new RecetaDao();
        }

        public bool ConfirmarReceta(Receta nuevo)
        {
            return dao.Save(nuevo);
        }

        public List<Ingrediente> ObtenerIngredientes()
        {
            return dao.ToGetIngredientes();
        }

        public int ProximaReceta()
        {
            return dao.ObtenerProximoID();
        }
    }
}
