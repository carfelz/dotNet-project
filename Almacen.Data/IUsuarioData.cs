using Almacen.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
   public interface IUsuarioData
    {
        IEnumerable<Usuarios>GetUsuarios();
        Usuarios GetById(int id);
        Usuarios Update(Usuarios user);
        Usuarios Add(Usuarios newUser);
        Usuarios Delete(int id);
        int Commit();

    }

    public class SqlUsuariosData : IUsuarioData
    {
        private readonly AlmacenDbContext almacenDb;

        public SqlUsuariosData( AlmacenDbContext almacenDb)
        {
            this.almacenDb = almacenDb;
        }
        public Usuarios Add(Usuarios newUser)
        {
            almacenDb.Add(newUser);
            return newUser;
        }

        public int Commit()
        {
            return almacenDb.SaveChanges();
        }

        public Usuarios Delete(int id)
        {
            var usuarios = GetById(id);
            if(usuarios != null)
            {
                almacenDb.Remove(usuarios);
            }

            return usuarios;
        }

        public Usuarios GetById(int id)
        {
           return almacenDb.Usuario.Find(id);
        }

        public IEnumerable<Usuarios> GetUsuarios()
        {
            var query = from u in almacenDb.Usuario
                        orderby u.Id
                        select u;
            return query;
        }

        public Usuarios Update(Usuarios user)
        {
            var updated = almacenDb.Usuario.Attach(user);
            updated.State = EntityState.Modified;
            return user;
        }
    }

    public class InMemoryUsuario : IUsuarioData
    {
        readonly List<Usuarios> usuarios;
       

        public InMemoryUsuario()
        {
            usuarios = new List<Usuarios>()
            {
                new Usuarios {Id= 1, Nombre="Jazmin", Apellido="Garcia", Contrasena="123456789", Estado=Estado.Activos, Correo="mgarcias@gmaik.com", Rol=Rol.Administrado},
                new Usuarios {Id= 2, Nombre="Pablo", Apellido="Garcia", Contrasena="123456700", Estado=Estado.Activos, Correo="mgarcias@gmaik.com", Rol=Rol.Empleado},
                new Usuarios {Id= 3, Nombre="Isaura", Apellido="Garcia", Contrasena="123456000", Estado=Estado.Activos, Correo="mgarcias@gmaik.com", Rol=Rol.Empleado},
                new Usuarios {Id= 4, Nombre="Migdalia", Apellido="Garcia", Contrasena="123456111", Estado=Estado.Activos, Correo="mgarcias@gmaik.com", Rol=Rol.Contratista}

            };
        }

        public Usuarios Update(Usuarios user)
        {
            var Usuarios = usuarios.SingleOrDefault(u => u.Id == user.Id);
            if(Usuarios != null)
            {
                Usuarios.Nombre = user.Nombre;
                Usuarios.Apellido = user.Apellido;
                Usuarios.Contrasena = user.Contrasena;
                Usuarios.Estado = user.Estado;
                Usuarios.Correo = user.Correo;
                Usuarios.Rol = user.Rol;
            }
            return Usuarios;
        }

        public int Commit()
        {
            return 0;
        }

        public Usuarios GetById(int id)
        {

            return usuarios.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Usuarios> GetUsuarios()
        {
            return from u in usuarios
                   orderby u.Id
                   select u;
        }

        public Usuarios Add(Usuarios newUser)
        {
            usuarios.Add(newUser);
            newUser.Id = usuarios.Max(r => r.Id) + 1;
            return newUser;
        }

        public Usuarios Delete(int id)
        {
            var user = usuarios.FirstOrDefault(u => u.Id == id);

            if(user != null)
            {
                usuarios.Remove(user);
            }
            return user;
        }
    }
}
