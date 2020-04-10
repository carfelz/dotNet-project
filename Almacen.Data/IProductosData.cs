using Almacen.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
    public interface IProductosData
    {
        IEnumerable<Productos> GetProductos();
        Productos GetById(int id);
        Productos Update(Productos product);
        Productos Add(Productos newproduct);
        Productos Delete(int id);
        int Commit();
    }

    public class SqlProductosData : IProductosData
    {
        private readonly AlmacenDbContext almacenDb;

        public SqlProductosData(AlmacenDbContext almacenDb)
        {
            this.almacenDb = almacenDb;
        }

        public Productos Add(Productos newproduct)
        {
            almacenDb.Add(newproduct);
            return newproduct;
        }

        public int Commit()
        {
            return almacenDb.SaveChanges();
        }

        public Productos Delete(int id)
        {
            var prod = GetById(id);
            if(prod != null)
            {
                almacenDb.Remove(prod);
            }
            return prod;
        }

        public Productos GetById(int id)
        {
            return almacenDb.Producto.Find(id);
        }

        public IEnumerable<Productos> GetProductos()
        {
            var query = from u in almacenDb.Producto
                        orderby u.Id
                        select u;
            return query;
        }

        public Productos Update(Productos product)
        {
            var updated = almacenDb.Producto.Attach(product);
            updated.State = EntityState.Modified;
            return product;
        }
    }
    public class InMemoryProducto : IProductosData
    {
        readonly List<Productos> producto;
        public InMemoryProducto()
        {
            producto = new List<Productos>()
            {
                new Productos{ Id = 1, FechaCreacion= new DateTime(2018, 05, 05), FechaVencimiento = new DateTime(2021, 05,05), Nombre= "Alcohol", Descripcion="Alcohol Isopropilico 15%", UdM = "gal", IsExistente= true, Estado= Estado.Activos, Precio= 10.5 },
                new Productos{ Id = 2, FechaCreacion= new DateTime(2018, 05, 05), FechaVencimiento = new DateTime(2021, 05,05), Nombre= "Cerveza", Descripcion="Cerveza Alemana", UdM = "gal", IsExistente= true, Estado= Estado.Inactivo, Precio= 15.5 },
                new Productos{ Id = 3, FechaCreacion= new DateTime(2018, 05, 05), FechaVencimiento = new DateTime(2021, 05,05), Nombre= "Vino", Descripcion="Vino tinto de la rioja", UdM = "gal", IsExistente= true, Estado= Estado.Activos, Precio= 19.5 },
                new Productos{ Id = 4, FechaCreacion= new DateTime(2018, 05, 05), 
                    FechaVencimiento = new DateTime(2021, 05,05), Nombre= "Vodka", 
                    Descripcion="Vodka Ruso", UdM = "gal", IsExistente= true, 
                    Estado= Estado.Activos, Precio= 32.5 }

            };


        }

        public IEnumerable<Productos> GetProductos()
        {
            return from p in producto
                   orderby p.Id
                   select p;
        }

        public Productos Update(Productos productos)
        {
            var Productos = producto.SingleOrDefault(u => u.Id == productos.Id);
            if (Productos != null)
            {
                Productos.FechaCreacion = productos.FechaCreacion;
                Productos.FechaVencimiento = productos.FechaVencimiento;
                Productos.Nombre = productos.Nombre;
                Productos.Estado = productos.Estado;
                Productos.Descripcion = productos.Descripcion;
                Productos.UdM = productos.UdM;
                Productos.IsExistente = productos.IsExistente;
                Productos.Precio = productos.Precio;

            }
            return Productos;
        }

        public int Commit()
        {
            return 0;
        }

        public Productos GetById(int id)
        {

            return producto.SingleOrDefault(r => r.Id == id);
        }

  

        public Productos Add(Productos newproduct)
        {
            producto.Add(newproduct);
            newproduct.Id = producto.Max(r => r.Id) + 1;
            return newproduct;
        }

        public Productos Delete(int id)
        {
            var user = producto.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                producto.Remove(user);
            }
            return user;
        }
    }
}
