using System;
using System.Collections.Generic;
using System.Text;

namespace Wooza.PlanosTelefonia.Dominio
{
    public class Operadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PlanoTelefonia> PlanosTelefonicos { get; set; }
    }
}
