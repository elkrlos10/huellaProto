using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.Models
{
    public class EnergiaM
    {
        public int IdEnergia { get; set; }

        public int IdProyecto { get; set; }

        public double EnergiaKwh { get; set; }

        public double Gas { get; set; }

        public bool EnergiaRenovable { get; set; }
    }
}
