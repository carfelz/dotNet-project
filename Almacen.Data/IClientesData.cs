using Almacen.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
    public interface IClientesData
    {
        IEnumerable<Clientes> GetClientes();
        Clientes GetById(int id);
        Clientes Update(Clientes cliente);
        Clientes Add(Clientes newcliente);
        Clientes Delete(int id);
        int Commit();
    }

    public class SqlClientesData : IClientesData
    {
        private readonly AlmacenDbContext almacenDb;

        public SqlClientesData( AlmacenDbContext almacenDb)
        {
            this.almacenDb = almacenDb;
        }

        public Clientes Add(Clientes newcliente)
        {
            almacenDb.Cliente.Add(newcliente);
            return newcliente;
        }

        public int Commit()
        {
            return almacenDb.SaveChanges();
        }

        public Clientes Delete(int id)
        {
          var  entity = GetById(id);
            if(entity != null)
            {
                almacenDb.Remove(entity);
            }
            return entity;
        }

        public Clientes GetById(int id)
        {
            var query = almacenDb.Cliente.Find(id);
            return query;
        }

        public IEnumerable<Clientes> GetClientes()
        {
            var query = from c in almacenDb.Cliente
                        orderby c.Id
                        select c;
            return query;
        }

        public Clientes Update(Clientes cliente)
        {
            var update = almacenDb.Cliente.Attach(cliente);
            update.State = EntityState.Modified;
            return cliente; 
        }
    }
    public class InMemoryClientes : IClientesData
    {
        readonly List<Clientes> Cliente;
        public InMemoryClientes()
        {
            Cliente = new List<Clientes>()
            {
                new Clientes{ Id=1, Nombre="Carlos", Apellido="Feliz", Correo="carlosjfeliz7@gmail.com", Direccion="C/ primera los girasoles", Telefono="809-365-1974", TipoCliente=TipoCliente.PersonaFisica },
                new Clientes{ Id=2, Nombre="Cesar", Apellido="Feliz", Correo="carlosjfeliz7@gmail.com", Direccion="C/ primera los girasoles", Telefono="809-365-1873", TipoCliente=TipoCliente.Empresa },
                new Clientes{ Id=3, Nombre="Eduardo", Apellido="Feliz", Correo="carlosjfeliz7@gmail.com", Direccion="C/ primera los girasoles", Telefono="809-365-1762", TipoCliente=TipoCliente.PersonaFisica },
                new Clientes{ Id = 4, Nombre = "Elim", Apellido = "Feliz", Correo = "carlosjfeliz7@gmail.com", Direccion = "C/ primera los girasoles", Telefono = "809-365-1951", TipoCliente = TipoCliente.Empresa }
             };
        }

        public Clientes Add(Clientes newcliente)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Clientes Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Clientes GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clientes> GetClientes()
        {
            return from c in Cliente
                   orderby c.Id
                   select c;
        }

        public Clientes Update(Clientes cliente)
        {
            throw new NotImplementedException();
        }
    }
} 