﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Core
{
    public class Clientes

    {
        public int Id { get; set; }
        public string  Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public TipoCliente TipoCliente { get; set; }
    }
}