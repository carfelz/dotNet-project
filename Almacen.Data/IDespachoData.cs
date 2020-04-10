using Almacen.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
    public interface IDespachoData
    {
        IEnumerable<DespachoProductos> GetDespachoProductos();
        DespachoProductos GetById(int id);
        DespachoProductos Update(DespachoProductos despacho);
        DespachoProductos Add(DespachoProductos newDespacho);
        DespachoProductos Delete(int id);
        int Commit();
    }

    public class SqlDespachoData : IDespachoData
    {
        private readonly AlmacenDbContext almacenDb;

        public SqlDespachoData(AlmacenDbContext almacenDb)
        {
            this.almacenDb = almacenDb;
        }

        public DespachoProductos Add(DespachoProductos despacho)
        {
            almacenDb.Add(despacho);
            return despacho;
        }

        public int Commit()
        {
            return almacenDb.SaveChanges();
        }

        public DespachoProductos Delete(int id)
        {
            var desp = GetById(id);
            if(desp != null)
            {
                almacenDb.Remove(desp);
            }

            return desp;
        }

        public DespachoProductos GetById(int id)
        {
            var despach = almacenDb.Despacho.Find(id);
            return despach;
        }

        public IEnumerable<DespachoProductos> GetDespachoProductos()
        {
            var query = from d in almacenDb.Despacho
                        orderby d.Id
                        select d;
            return query;

        }

        public DespachoProductos Update(DespachoProductos despacho)
        {
            
                var updated = almacenDb.Despacho.Attach(despacho);
                updated.State = EntityState.Modified;
            

            return despacho;
        }
    }



  /*  public class InMemoryDespachos : IDespachoData
    {
        readonly List<DespachoProductos> despachoProductos;
        public InMemoryDespachos()
        {
            despachoProductos = new List<DespachoProductos>()
            {
                new DespachoProductos{Id= 1, Fecha= new DateTime(2020, 9, 7), Cliente= "Carlos Feliz", Contacto="Telefono", Detalle="un detallito", TipoAccion= TipoAccion.Entrada },
                new DespachoProductos{Id= 2, Fecha= new DateTime(2020, 10, 6), Cliente= "Carlos Feliz", Contacto="Telefono", Detalle="un detallito", TipoAccion= TipoAccion.Entrada },
                new DespachoProductos{Id= 3, Fecha= new DateTime(2020, 11, 5), Cliente= "Carlos Feliz", Contacto="Telefono", Detalle="un detallito", TipoAccion= TipoAccion.Entrada },
                new DespachoProductos{Id= 4, Fecha= new DateTime(2020, 12, 4), Cliente= "Carlos Feliz", Contacto="Telefono", Detalle="un detallito", TipoAccion= TipoAccion.Entrada }
            };

        }
        public IEnumerable<DespachoProductos> GetDespachoProductos()
        {
            return from d in despachoProductos
                   orderby d.Id
                   select d;
        }
    }*/
}
