using System.Diagnostics.Contracts;
using AutoMapper;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using FilmesAPI.Models;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController: ControllerBase
    {

        private SessaoService sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            this.sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto readDto = sessaoService.RecuperaSessoesPorId(id);
            if(readDto == null)return NotFound();
            return Ok(readDto);
        }

        [HttpGet]
        public IActionResult RecuperaSessao()
        {
            List<ReadSessaoDto> readDto = sessaoService.RecuperaSessao();
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }
    }
}
