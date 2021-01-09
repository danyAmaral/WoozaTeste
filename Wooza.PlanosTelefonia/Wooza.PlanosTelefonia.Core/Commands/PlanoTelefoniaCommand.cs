using Wooza.PlanosTelefonia.Dominio;

namespace Wooza.PlanosTelefonia.Core.Commands
{
    public class PlanoTelefoniaCommand
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public string FranquiaInternet { get; set; }
        public decimal Valor { get; set; }
        public int DDDId { get; set; }
        public int OperadoraId { get; set; }
        public TipoPlano TipoPlano { get; set; }
    }
}
