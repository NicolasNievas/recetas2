using recetas2.datos.Interfaces;
using recetas2.dominio;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetas2.datos.Implementaciones
{
    public class RecetaDao : IRecetaDao
    {
        

        public int ObtenerProximoID()
        {
            return HelperDao.ObtenerInstancia().ObtenerProximoID("SP_PROXIMO_ID", "@next");
        }

        public bool Save(Receta nuevo)
        {
            return HelperDao.ObtenerInstancia().GrabarReceta(nuevo, "SP_INSERTAR_RECETA", "SP_INSERTAR_DETALLE");
        }

        public List<Ingrediente> ToGetIngredientes()
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            DataTable dt = HelperDao.ObtenerInstancia().CargarCombo("SP_CONSULTAR_INGREDIENTES");
            foreach(DataRow dr in dt.Rows)
            {
                Ingrediente i = new Ingrediente();
                i.IngredienteID = (int)dr["id_ingrediente"];
                i.Nombre = dr["n_ingrediente"].ToString();
                i.UnidadMedida = dr["unidad_medida"].ToString();
                ingredientes.Add(i);
            }
            return ingredientes;
        }
    }
}
