using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.Core;
using Almacen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Almacen.Pages
{
    public class EditAdministracionModel : PageModel
    {
        private readonly IUsuarioData usuarioData;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> Rol { get; set; }
        public IEnumerable<SelectListItem> Estado { get; set; }
        [BindProperty]
        public Usuarios Usuarios { get; set; }



        public EditAdministracionModel(IUsuarioData usuarioData, IHtmlHelper htmlHelper)
        {
            this.usuarioData = usuarioData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnPost()
        {
            Rol = htmlHelper.GetEnumSelectList<Rol>();
            Estado = htmlHelper.GetEnumSelectList<Estado>();

            if (Usuarios.Id > 0)
            {
                usuarioData.Update(Usuarios);
            }
            else
            {
                usuarioData.Add(Usuarios);
            }
            usuarioData.Commit();
            return RedirectToPage("/Administracion");
        }


        public IActionResult OnGet(int? userId)
        {
            Rol = htmlHelper.GetEnumSelectList<Rol>();
            Estado = htmlHelper.GetEnumSelectList<Estado>();

            if (userId.HasValue)
            {
                Usuarios = usuarioData.GetById(userId.Value);
            }
            else
            {
                Usuarios = new Usuarios();
            }

            if (Usuarios == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();

        }
    }
}
