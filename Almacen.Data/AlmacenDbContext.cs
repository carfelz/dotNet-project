using Almacen.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Data
{
    public class AlmacenDbContext : DbContext
    {
        public AlmacenDbContext(DbContextOptions<AlmacenDbContext> options)
         :base(options)
        {

        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<DespachoProductos> Despacho { get; set; }
        public DbSet<Productos> Producto { get; set; }
    }
}
