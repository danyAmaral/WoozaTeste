using System;
using System.Collections.Generic;
using System.Text;

namespace Wooza.PlanosTelefonia.Dominio.Interfaces
{
    public interface IPlanoTelefonia : IRepositorio<PlanoTelefonia>
    {
        List<PlanoTelefonia> Get();
    }
}
