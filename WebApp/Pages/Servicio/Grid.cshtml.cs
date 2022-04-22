//KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
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
    public class GridModel : PageModel
    {
        private readonly IServicioService servicio;

        public GridModel(IServicioService servicio)
        {
            this.servicio = servicio;
        }

        public IEnumerable<ServicioEntity> GridList { get; set; } = new List<ServicioEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await servicio.Get();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<JsonResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await servicio.Delete(new()
                {
                    IdServicio = id
                });
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

    //*******************************
}
