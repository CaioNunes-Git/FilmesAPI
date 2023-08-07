using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly FilmeContext _context;
        private IMapper _mapper;

        public FilmeRepository(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Filme> ListarTodos(int skip, int take)
        {
            return _context.Filmes.Skip(skip).Take(take);
        }

        public Filme AdicionarFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return filme;
        }

        public void ApagarFilme(int id)
        {
            Filme? filmeEncontrado = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            //return _context.Filmes.Remove(filmeEncontrado);
        }

        public Filme BuscarFilmePorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            return filme;
        }

        public Filme EditarFilme(int id, UpdateFilmeDto filme)
        {
            Filme? filmeEncontrado = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            _mapper.Map(filme, filmeEncontrado);
            _context.SaveChanges();

            return filmeEncontrado;
        }
    }
}
