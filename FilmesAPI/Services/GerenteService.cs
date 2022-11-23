using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext context;
        private IMapper mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = mapper.Map<Gerente>(gerenteDto);
            context.Gerentes.Add(gerente);
            context.SaveChanges();
            return mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente gerente = context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }
            return null;
        }

        public List<ReadGerenteDto> RecuperaGerentes()
        {
            List<Gerente> gerente = context.Gerentes.ToList();
            if(gerente != null)
            {
                List<ReadGerenteDto> readDto = mapper.Map<List<ReadGerenteDto>>(gerente);
                return readDto;
            }
            return null;
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                context.Remove(gerente);
                context.SaveChanges();
                return Result.Ok();
            }
            List<IError> error = new List<IError>();

            
            return Result.Fail("Gerente não Encontrado.");
        }
    }
}
