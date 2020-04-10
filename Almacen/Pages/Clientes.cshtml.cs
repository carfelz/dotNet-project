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
    public class ClientesModel : PageModel
    {
        private readonly IClientesData clientesData;
        public IEnumerable<Clientes> Clientes { get; set; }

        public ClientesModel(IClientesData clientesData)
        {
            this.clientesData = clientesData;
        }
       
        public void OnGet()
        {
            Clientes = clientesData.GetClientes();
          
        }
    }
}
