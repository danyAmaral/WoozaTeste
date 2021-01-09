using Microsoft.AspNetCore.Mvc;
using System;
using Wooza.PlanosTelefonia.Core.Interfaces;

namespace Wooza.PlanosTelefonia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosTelefoniaController : ControllerBase
    {
        private IPlanosTelefoniaService planoTelefoniaService;

        public PlanosTelefoniaController(IPlanosTelefoniaService planoTelefoniaService)
        {
            this.planoTelefoniaService = planoTelefoniaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var itens = planoTelefoniaService.GetAll();
            return base.Ok(itens);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                return Ok(planoTelefoniaService.GetByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}