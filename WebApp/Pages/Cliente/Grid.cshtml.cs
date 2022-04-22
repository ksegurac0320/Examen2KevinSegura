//KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Cliente
{
    public class GridModel : PageModel
    {
        private readonly IClienteService cliente;

        public GridModel(IClienteService cliente)
        {
            this.cliente = cliente;
        }

        public IEnumerable<ClienteEntity> GridList { get; set; } = new List<ClienteEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await cliente.Get();
                return Page();
            }
            catch (Exception Ex)
            {
                return Content(Ex.Message);
            }
        }

        public async Task<JsonResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await cliente.Delete(new()
                {
                    IdCliente = id
                }); 
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

    }

//*************************
}
