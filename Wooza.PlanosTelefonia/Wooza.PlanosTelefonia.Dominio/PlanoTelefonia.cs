using System;
using System.Collections.Generic;
using System.Text;

namespace Wooza.PlanosTelefonia.Dominio
{
    public class PlanoTelefonia
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public int FranquiaInternet { get; set; }
        public decimal Valor { get; set; }
        public string CodigoDDD { get; set; }
        public string OperadoraId { get; set; }
        public Operadora Operadora { get; set; }
        public DDD DDD { get; set; }
    }
}
