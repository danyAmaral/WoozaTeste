using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wooza.PlanosTelefonia.Dominio;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Infraestrutura
{
    public class PlanosTelefonia : Repositorio<PlanoTelefonia>, IPlanoTelefonia
    {
        public PlanosTelefonia(Contexto ctx) : base(ctx)
        {
        }


        public List<PlanoTelefonia> Get()
        {
            var query = this.ctx.PlanosTelefonia
                .Include(x => x.Operadora)
                .Include(x => x.DDD);

            return query.ToList();
        }


    }
}
