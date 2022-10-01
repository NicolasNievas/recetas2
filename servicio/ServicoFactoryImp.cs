using recetas2.servicio.Implementaciones;
using recetas2.servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetas2.servicio
{
    class ServicoFactoryImp : AbstractFactoryService
    {
        public override IServicio crearServicio()
        {
            return new ServicioReceta();
        }
    }
}
