using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext context;
        private IMapper mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = mapper.Map<Sessao>(sessaoDto);
            context.Sessoes.Add(sessao);
            context.SaveChanges();
            return mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = context.Sessoes.FirstOrDefault(s => s.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto readSessaoDto = mapper.Map<ReadSessaoDto>(sessao);
                return readSessaoDto;
            }
            return null;
        }

        public List<ReadSessaoDto> RecuperaSessao()
        {
            List<Sessao> sessoes = context.Sessoes.ToList();
            if(sessoes != null)
            {
                List<ReadSessaoDto> readDto = mapper.Map<List<ReadSessaoDto>>(sessoes);
                return readDto;
            }
            return null;
        }
    }
}
