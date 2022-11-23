using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext context;
        private IMapper mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = mapper.Map<Filme>(filmeDto);
            context.Filmes.Add(filme);
            context.SaveChanges();
            return mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperarFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = context.Filmes.ToList();
            }
            else
            {
                filmes = context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }
            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            Filme filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = mapper.Map<ReadFilmeDto>(filme);
                return filmeDto;
            }
            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não Encontrado.");
            }
            mapper.Map(filmeDto, filme);
            context.SaveChanges();
            return Result.Ok();

        }

        //Para usar o Result é necessário instalação do pacote pelo Nuget
        // Usa quando quer retornar apenas o status do metodo, se deu certo ou errado.
        public Result DeletaFilme(int id)
        {
            Filme filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não Encontrado");
            }
            context.Remove(filme);
            context.SaveChanges();
            return Result.Ok();
        }
    }
}
