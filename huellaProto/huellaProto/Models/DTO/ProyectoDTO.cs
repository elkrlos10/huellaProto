using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.Models.DTO
{
    public class ProyectoDTO
    {
        public int IdProyecto { get; set; }

        public DateTime FechaProyecto { get; set; }

        public int IdEmpresa { get; set; }

        public int Etapa { get; set; }

        public string NombreEmpresa { get; set; }


    }
}
