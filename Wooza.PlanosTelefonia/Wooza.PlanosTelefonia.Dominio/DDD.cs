using System;
using System.Collections.Generic;
using System.Text;

namespace Wooza.PlanosTelefonia.Dominio
{
    public class DDD
    {
        public int Codigo { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public List<PlanoTelefonia> PlanosTelefonicos { get; set; }
    }
}
