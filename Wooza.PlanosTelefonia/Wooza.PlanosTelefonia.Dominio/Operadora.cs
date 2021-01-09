using System.Collections.Generic;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Dominio
{
    public class Operadora : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PlanoTelefonia> PlanosTelefonicos { get; set; }
    }
}
