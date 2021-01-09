using Microsoft.AspNetCore.Mvc;
using Wooza.PlanosTelefonia.Core.Interfaces;
using Wooza.PlanosTelefonia.Dominio;

namespace Wooza.PlanosTelefonia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        private IPlanosTelefoniaService planoTelefoniaService;

        public PesquisaController(IPlanosTelefoniaService planoTelefoniaService)
        {
            this.planoTelefoniaService = planoTelefoniaService;
        }

        [HttpGet, Route("")]
        public IActionResult Filtrar(int ddd, int? operadora, TipoPlano? tipo, int? idPlano)
        {
            var planos = planoTelefoniaService.Filtrar(ddd, operadora, tipo, idPlano);
            return base.Ok(planos);
        }
    }
}