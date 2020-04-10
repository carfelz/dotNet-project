using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Core
{
   public class Productos
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UdM { get; set; }
        public double Precio { get; set; }
        public bool IsExistente { get; set; }
        public Estado Estado { get; set; }
    }
}
