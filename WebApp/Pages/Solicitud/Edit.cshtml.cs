using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Solicitud
{
    public class EditModel : PageModel
    {
        private readonly ISolicitudService solicitud;
        private readonly IClienteService cliente;
        private readonly IServicioService servicio;

        public EditModel(ISolicitudService solicitud, IClienteService cliente, IServicioService servicio)
        {
            this.solicitud = solicitud;
            this.cliente = cliente;
            this.servicio = servicio;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }//el signo es par que el campo permita nulos en el caso que se vaya a hacer un insert

        [BindProperty]
        [FromBody]
        public SolicitudEntity Entity { get; set; } = new SolicitudEntity();// para guardar los datos de la entidad

        public IEnumerable<ClienteEntity> ClienteListar { get; set; } = new List<ClienteEntity>();
        public IEnumerable<ServicioEntity> ServicioListar { get; set; } = new List<ServicioEntity>();

        //Metodo edit
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await solicitud.GetById(new()
                    {
                        IdSolicitud = id
                    });
                }
                ClienteListar = await cliente.GetLista();
                ServicioListar = await servicio.GetLista();
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
                if (Entity.IdSolicitud.HasValue) //si el idSolicitud tiene un valor (true) el metodo actuliza
                {        
                    result = await solicitud.Update(Entity);
                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {                    
                    result = await solicitud.Create(Entity);
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

//*********************
}
