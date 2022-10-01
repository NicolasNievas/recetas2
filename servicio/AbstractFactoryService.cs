using recetas2.servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recetas2.servicio
{
    abstract class AbstractFactoryService
    {
        public abstract IServicio crearServicio();
    }
}
