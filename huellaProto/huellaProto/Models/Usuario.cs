using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.Models
{
    public class Usuario
    {
    
        public int IdUsuario { get; set; }

       
        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public int TipoUsuario { get; set; }
    }
}
