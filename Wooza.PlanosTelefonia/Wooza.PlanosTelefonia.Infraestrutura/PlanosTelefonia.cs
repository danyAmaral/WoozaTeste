using Wooza.PlanosTelefonia.Dominio;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Infraestrutura
{
    public class PlanosTelefonia : Repositorio<PlanoTelefonia>, IPlanoTelefonia
    {
        public PlanosTelefonia(Contexto ctx) : base(ctx)
        {
        }
    }
}
