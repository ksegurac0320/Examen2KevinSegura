//Kevin Segura Calvo Examen 2 UTC Progra 6 Viernes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SolicitudEntity : DBEntity
    {
        public SolicitudEntity()
        {
            Cliente = Cliente ?? new ClienteEntity();
            Servicio = Servicio ?? new ServicioEntity();
        }

        public int? IdSolicitud { get; set; } //? = Nullable 
        public int? IdCliente { get; set; } //? = Nullable 
        public virtual ClienteEntity Cliente { get; set; }
        public int? IdServicio { get; set; } //? = Nullable 
        public virtual ServicioEntity Servicio { get; set; }
        public int? Cantidad { get; set; }  //? = Nullable 
        public int? Monto { get; set; } //? = Nullable 
        public DateTime FechaEntrega { get; set; } = DateTime.Now; //para dar la fecha actual
        public string UsuarioEntrega { get; set; }
        public string Observaciones { get; set; }

    }

    //**************************
}
