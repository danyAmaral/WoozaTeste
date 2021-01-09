using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Dominio
{
    public class PlanoTelefonia : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public string FranquiaInternet { get; set; }
        public decimal Valor { get; set; }
        public int DDDId { get; set; }
        public int OperadoraId { get; set; }
        public TipoPlano TipoPlano { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual DDD DDD { get; set; }
    }
}
