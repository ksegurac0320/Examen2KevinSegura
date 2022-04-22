//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
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
    public class EditModel : PageModel
    {
        private readonly IClienteService cliente;

        public EditModel(IClienteService cliente)
        {
            this.cliente = cliente;

        }

        [BindProperty(SupportsGet = true)]//para que no se filtre los ids en los url y evitar robo
        public int? id { get; set; }  //el signo es par que el campo permita nulos en el caso que se vaya a hacer un insert

        [BindProperty]
        [FromBody]
        public ClienteEntity Entity { get; set; } = new ClienteEntity(); // para guardar los datos de la entidad

        //metodo edit
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await cliente.GetById(new()
                    {
                        IdCliente = id
                    });
                }

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //metodo update insert
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                //update
                if (Entity.IdCliente.HasValue) //si el idCliente tiene un valor (true) el metodo actuliza
                {
                    result = await cliente.Update(Entity);

                }
                else //Si el idCliente no tiene valor (false) el metodo inserta
                {   
                    result = await cliente.Create(Entity);

                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }

    //****************************
}
