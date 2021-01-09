using System.Collections.Generic;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Dominio
{
    public class DDD : IEntity
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public List<PlanoTelefonia> PlanosTelefonicos { get; set; }
    }
}
