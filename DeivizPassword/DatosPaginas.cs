using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeivizPassword
{
    class DatosPaginas
    {
        public string pagina { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string descripcion { get; set; }

        public DatosPaginas()
        {
            pagina = "";
            usuario = "";
            contraseña = "";
            descripcion = "";
        }

    }
}
