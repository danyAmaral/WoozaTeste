using Wooza.PlanosTelefonia.Dominio;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Infraestrutura
{
    public class Operadoras : Repositorio<Operadora>, IOperadora
    {
        public Operadoras(Contexto ctx) : base(ctx)
        {
        }
    }
}
