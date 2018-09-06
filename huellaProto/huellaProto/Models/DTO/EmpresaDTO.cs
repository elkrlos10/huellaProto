using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.Models.DTO
{
    public class EmpresaDTO
    {
        public int IdEmpresa { get; set; }

        public string NombreEmpresa { get; set; }

        public string Nit { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }

        public int TipoEmpresa { get; set; }

        public int TipoUsuario { get; set; }

        public int IdUsuario { get; set; }

        public string Password { get; set; }
    }
}
