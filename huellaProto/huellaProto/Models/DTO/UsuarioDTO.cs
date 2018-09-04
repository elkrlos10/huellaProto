using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.Models.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public int TipoUsuario { get; set; }

        public int TipoEmpresa { get; set; }
    }
}
