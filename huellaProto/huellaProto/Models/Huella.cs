using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.Models
{
   public class Huella
    {
        public int IdHuella { get; set; }
        public int IdProyecto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoArbol { get; set; }
        public string Zona { get; set; }
        public bool Precisar { get; set; }
        public double Toneledas { get; set; }

    }
}
