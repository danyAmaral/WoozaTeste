namespace Wooza.PlanosTelefonia.Core.Views
{
    public class PlanoTelefoniaView
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public string FranquiaInternet { get; set; }
        public decimal Valor { get; set; }
        public string TipoPlano { get; set; }
        public string Operadora { get; set; }
        public int DDD { get; set; }
    }
}
