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
    public class ProductosModel : PageModel
    {
        private readonly IProductosData productosData;
        public IEnumerable<Productos> productos { get; set; }

        public ProductosModel( IProductosData data) 
        {
            this.productosData = data;
        }
        public void OnGet()
        {
            productos = productosData.GetProductos();

        }
    }
}
