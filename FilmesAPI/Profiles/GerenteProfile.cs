using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts
                 => opts
                 .MapFrom(gerente => gerente.Cinemas.Select
                 (c => new { c.Id, c.Nome, c.Endereco})));
    } 
    }
}
