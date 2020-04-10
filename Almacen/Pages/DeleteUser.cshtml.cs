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
    public class DeleteUserModel : PageModel
    {
        private readonly IUsuarioData usuarioData;

        [BindProperty]
        public Usuarios Usuarios { get; set; }

        public DeleteUserModel(IUsuarioData data)
        {
            this.usuarioData = data;
        }
        public IActionResult OnGet(int userId)
        {
            Usuarios = usuarioData.GetById(userId);
            return Page();
        }

        public IActionResult OnPost(int userId)
        {
            var user = usuarioData.Delete(userId);
            usuarioData.Commit();
            if(user == null)
            {
                RedirectToPage("/NotFound");
            }

            return RedirectToPage("/Administracion");
        }
    }
}
