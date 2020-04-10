using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Almacen.Core
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public Rol Rol { get; set; }
        public Estado Estado { get; set; }

    }
}
