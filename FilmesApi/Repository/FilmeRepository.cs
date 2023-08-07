using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly FilmeContext _context;


        public FilmeRepository(FilmeContext context)
        {
            _context = context;
        }
        public IEnumerable<Filme> ListarTodos(int skip, int take)
        {
            return _context.Filmes.Skip(skip).Take(take);
        }

        public Filme AdicionarFilme(Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();
            return filme;
        }

        public void ApagarFilme(Filme filme)
        {
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
        }

        public Filme BuscarFilmePorId(int id)
        {
            var filme = _context.Filmes.AsNoTracking().FirstOrDefault(filmes => filmes.Id == id);
            return filme;
        }

        public Filme EditarFilme(Filme filme)
        {
            _context.Update(filme);
            _context.SaveChanges();
            return filme;
        }
    }
}
