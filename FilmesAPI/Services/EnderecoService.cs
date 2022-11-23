using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext context;
        private IMapper mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = mapper.Map<Endereco>(enderecoDto);
            context.Enderecos.Add(endereco);
            context.SaveChanges();
            return mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaEnderecos()
        {
            List<Endereco> enderecos = context.Enderecos.ToList();
            if(enderecos == null)
            {
                return null;
            }
            return mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        public ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoDto;
            }
            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = context.Enderecos.FirstOrDefault(x => x.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereço não Encontrado.");
            }
            mapper.Map(enderecoDto, endereco);
            context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            Endereco endereco = context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereço não encontrado.");
            }
            context.Remove(endereco);
            context.SaveChanges();
            return Result.Ok();
        }
    }
}
