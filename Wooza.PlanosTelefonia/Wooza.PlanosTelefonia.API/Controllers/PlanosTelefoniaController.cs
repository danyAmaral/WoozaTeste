using Microsoft.AspNetCore.Mvc;
using System;
using Wooza.PlanosTelefonia.Core.Commands;
using Wooza.PlanosTelefonia.Core.Interfaces;
using Wooza.PlanosTelefonia.Dominio;

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
           var planos = planoTelefoniaService.GetAll();
            return base.Ok(planos);
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

        [HttpPost, Route("")]
        public IActionResult Criar(PlanoTelefoniaCommand plano)
        {
            try
            {
                var novoPlano = planoTelefoniaService.Criar(plano);
                return Ok(novoPlano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("{id}")]
        public IActionResult Atualizar(PlanoTelefoniaCommand plano)
        {
            try
            {
                var planoAtualizado = planoTelefoniaService.Atualizar(plano);
                return Ok(planoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                planoTelefoniaService.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}