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
    public class DespachoModel : PageModel
    {
        private readonly IDespachoData despachoData;
        public IEnumerable<DespachoProductos> despachoProductos { set; get; }

        public DespachoModel(IDespachoData data)
        {
            this.despachoData = data;
        }
        public void OnGet()
        {
            despachoProductos = despachoData.GetDespachoProductos();
        }
    }
}
