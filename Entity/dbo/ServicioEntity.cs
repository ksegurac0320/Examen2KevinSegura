//Kevin Segura Calvo Examen 2 UTC Progra 6 Viernes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ServicioEntity : DBEntity
    {
        public int? IdServicio { get; set; } //? = Nullable 
        public string NombreServicio { get; set; }
        public int? PlazoEntrega { get; set; } //? = Nullable 
        public int? CostoServicio { get; set; } //? = Nullable 
        public int? Estado { get; set; } //? = Nullable 
        public string CuentaContable { get; set; }
    }


//********************************************
}
