using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Core
{
   public class DespachoProductos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TipoAccion TipoAccion { get; set; }
        public string Cliente { get; set; }
        public string  Contacto { get; set; }
        public string Detalle { get; set; }
    }
}
