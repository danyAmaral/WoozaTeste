using System.Collections.Generic;
using Wooza.PlanosTelefonia.Core.Commands;
using Wooza.PlanosTelefonia.Core.Views;
using Wooza.PlanosTelefonia.Dominio;

namespace Wooza.PlanosTelefonia.Core.Interfaces
{
    public interface IPlanosTelefoniaService
    {
        PlanoTelefonia Atualizar(PlanoTelefoniaCommand planoTelefonia);
        PlanoTelefonia Criar(PlanoTelefoniaCommand planoTelefonia);
        void Deletar(int id);
        List<PlanoTelefoniaView> GetAll();
        PlanoTelefoniaView GetByID(int id);
    }
}
