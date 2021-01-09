using Wooza.PlanosTelefonia.Dominio;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Infraestrutura
{
    public class DDDs : Repositorio<DDD>, IDDD
    {
        public DDDs(Contexto ctx) : base(ctx)
        {
        }
    }
}
