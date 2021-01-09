using System.Collections.Generic;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Dominio
{
    public class Operadora : IEntity
    {

        public Operadora()
        {
            PlanosTelefonicos = new HashSet<PlanoTelefonia>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<PlanoTelefonia> PlanosTelefonicos { get; set; }
    }
}
