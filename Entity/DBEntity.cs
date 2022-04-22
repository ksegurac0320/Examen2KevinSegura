using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DBEntity
    {   //clase oara mappear los errores que sql nos envie
        public int CodeError { get; set; }
        public string MsgError { get; set; }
    }
}
