using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.Models
{
    public class Residuos
    {
        public int IdResiduo { get; set; }

        public int IdProyecto { get; set; }

        public bool SeparacionResiduos { get; set; }

        public bool ProgramaReciclaje { get; set; }

        public bool Compostaje { get; set; }

        public double Can_ResiduosSolidos { get; set; }

        public double Can_RediduosRecicla { get; set; }
    }
}
