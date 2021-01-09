using System;
using System.Collections.Generic;
using Wooza.PlanosTelefonia.Core.Commands;
using Wooza.PlanosTelefonia.Core.Interfaces;
using Wooza.PlanosTelefonia.Core.Views;
using Wooza.PlanosTelefonia.Dominio;
using Wooza.PlanosTelefonia.Dominio.Interfaces;

namespace Wooza.PlanosTelefonia.Core.Services
{
    public class PlanosTelefoniaService : IPlanosTelefoniaService
    {
        private IPlanoTelefonia planoTelefoniaRepositorio;
        public PlanosTelefoniaService(IPlanoTelefonia planoTelefoniaRepositorio)
        {
            this.planoTelefoniaRepositorio = planoTelefoniaRepositorio;
        }

        public PlanoTelefonia Atualizar(PlanoTelefoniaCommand planoTelefoniaCommand)
        {
            PlanoTelefonia planoTelefonia = planoTelefoniaRepositorio.GetById(planoTelefoniaCommand.Id);
            var planoTelefoniaMapeado = Mapear(planoTelefoniaCommand, planoTelefonia);
            return planoTelefoniaRepositorio.Update(planoTelefoniaMapeado);
        }

        public PlanoTelefonia Criar(PlanoTelefoniaCommand planoTelefoniaCommand)
        {
            PlanoTelefonia planoTelefonia = Mapear(planoTelefoniaCommand, new PlanoTelefonia());
            return planoTelefoniaRepositorio.Create(planoTelefonia);
        }

        private PlanoTelefonia Mapear(PlanoTelefoniaCommand planoTelefoniaCommand, PlanoTelefonia planoTelefonia)
        {
            planoTelefonia.Id = planoTelefoniaCommand.Id;
            planoTelefonia.Codigo = planoTelefoniaCommand.Codigo;
            planoTelefonia.Minutos = planoTelefoniaCommand.Minutos;
            planoTelefonia.FranquiaInternet = planoTelefoniaCommand.FranquiaInternet;
            planoTelefonia.Valor = planoTelefoniaCommand.Valor;
            planoTelefonia.DDDId = planoTelefoniaCommand.DDDId;
            planoTelefonia.OperadoraId = planoTelefoniaCommand.OperadoraId;
            planoTelefonia.TipoPlano = planoTelefoniaCommand.TipoPlano;

            return planoTelefonia;
       }

        public void Deletar(int id)
        {
            var planoTelefonia = planoTelefoniaRepositorio.GetById(id);
            if (planoTelefonia == null)
                throw new Exception($"Plano com id {id} não encontrado.");
            planoTelefoniaRepositorio.Delete(id);
        }

        public List<PlanoTelefoniaView> GetAll()
        {
            var planosTelefonicosView = new List<PlanoTelefoniaView>();
            var planos = planoTelefoniaRepositorio.GetAll(null, x=> x.Operadora, x=> x.DDD);
            foreach (var plano in planos)
            {
                planosTelefonicosView.Add(Mapear(plano));
            }

            return planosTelefonicosView;
        }

        public PlanoTelefoniaView GetByID(int id)
        {
            var planoTelefonia = planoTelefoniaRepositorio.GetById(id, x=> x.Operadora, x=> x.DDD);
            if(planoTelefonia == null)
                throw new Exception($"Plano com id {id} não encontrado.");
            return Mapear(planoTelefonia);
        }

        public PlanoTelefoniaView Mapear(PlanoTelefonia planoTelefonia)
        {
            PlanoTelefoniaView planoTelefoniaView = new PlanoTelefoniaView();
            planoTelefoniaView.Id = planoTelefonia.Id;
            planoTelefoniaView.Codigo = planoTelefonia.Codigo;
            planoTelefoniaView.Minutos = planoTelefonia.Minutos;
            planoTelefoniaView.FranquiaInternet = planoTelefonia.FranquiaInternet;
            planoTelefoniaView.Valor = planoTelefonia.Valor;
            planoTelefoniaView.TipoPlano = planoTelefonia.TipoPlano.ToString();
            planoTelefoniaView.Operadora = planoTelefonia.Operadora.Nome;
            planoTelefoniaView.DDD = planoTelefonia.DDD.Codigo;

            return planoTelefoniaView;
        }
    }
}
