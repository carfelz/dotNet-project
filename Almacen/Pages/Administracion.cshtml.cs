using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Core;
using Almacen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Almacen.Pages
{
    public class UsuariosModel : PageModel
    {
        private readonly IUsuarioData usuarioData;

        public IEnumerable<Usuarios> usuarios { get; set; }

        public UsuariosModel(IUsuarioData data)
        {
            usuarioData = data;
        }
        public void OnGet()
        {
            usuarios = usuarioData.GetUsuarios();
        }
    }
}
