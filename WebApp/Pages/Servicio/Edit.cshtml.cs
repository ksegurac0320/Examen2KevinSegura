//*KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Servicio
{
    public class EditModel : PageModel
    {
        private readonly IServicioService servicio;

        public EditModel(IServicioService servicio)
        {
            this.servicio = servicio;
        }
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ServicioEntity Entity { get; set; } = new ServicioEntity();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await servicio.GetById(new()
                    {
                        IdServicio = id
                    });
                }
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                if (Entity.IdServicio.HasValue)
                {
                    result = await servicio.Update(Entity);
                }
                else
                {                   
                    result = await servicio.Create(Entity);
                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity
                {
                    CodeError = ex.HResult,
                    MsgError = ex.Message
                });
            }
        }
    }



    //*********************************
}
