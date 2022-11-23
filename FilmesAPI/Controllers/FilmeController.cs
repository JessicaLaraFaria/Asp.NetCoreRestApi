using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        //Configurar no Program.cs builder.Services.AddScoped<FilmeService, FilmeService>();
        private FilmeService filmeService;
        public FilmeController(FilmeService filmeService)
        {
            this.filmeService = filmeService;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = filmeService.AdicionaFilme(filmeDto);
            //CreatedAtAction mostra o status da solicitação e onde o recurso foi criado, é uma boa prática.
            return CreatedAtAction(nameof(RecuperaFilmesPorId),new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = filmeService.RecuperarFilmes(classificacaoEtaria);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto readDto = filmeService.RecuperaFilmesPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();       
        }

        [HttpPut("{id}")]
        public  IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = filmeService.AtualizaFilme(id, filmeDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = filmeService.DeletaFilme(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
