using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {

        private GerenteService gerenteService;
        public GerenteController(GerenteService gerenteService)
        {
            this.gerenteService = gerenteService;
        }   

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = gerenteService.AdicionaGerente(gerenteDto);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readDto = gerenteService.RecuperaGerentePorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<ReadGerenteDto> readDto = gerenteService.RecuperaGerentes();
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = gerenteService.DeletaGerente(id);
            if (resultado.IsFailed) return NotFound(resultado.Errors.Select(x=>x.Message));
            return NoContent();
        }


    }
}
