using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext context;
        private IMapper mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = mapper.Map<Cinema>(cinemaDto);
            context.Cinemas.Add(cinema);
            context.SaveChanges();
            return mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string? nomeDoFilme = null)
        {
            List<Cinema> cinemas = context.Cinemas.ToList();
            if (string.IsNullOrEmpty(nomeDoFilme))
            {
                List<ReadCinemaDto> readCinemaDto = mapper.Map<List<ReadCinemaDto>>(cinemas);
                return readCinemaDto;
            }
            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }
            return mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }
            return null;
        }

        public Result AdicionaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não Encontrado.");
            }
            mapper.Map(cinemaDto, cinema);
            context.SaveChanges();
            return Result.Ok();
        }

        internal Result DeletaCinema(int id)
        {
            Cinema cinema = context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não Encotrado.");
            }
            context.Remove(cinema);
            context.SaveChanges();
            return Result.Ok();
        }
    }
}
