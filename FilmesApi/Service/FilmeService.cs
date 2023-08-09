using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Repository;
using FilmesApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FilmesApi.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public IEnumerable<Filme> ListarTodos(int skip, int take)
        { 
            return _filmeRepository.ListarTodos(skip, take);
        }

        public Filme AdicionarFilme(Filme filme)
        {
            return _filmeRepository.AdicionarFilme(filme);
        }

        public void ApagarFilme(int id)
        {
            if (id == 0) throw new ArgumentNullException("O Id do teu filme ta zerado rapaz");
            Filme? filmeEncontrado = BuscarFilmePorId(id);
            _filmeRepository.ApagarFilme(filmeEncontrado);
        }

        public Filme BuscarFilmePorId(int id)
        {
            if (id == 0) throw new ArgumentNullException("O Id do teu filme ta zerado rapaz");
            return _filmeRepository.BuscarFilmePorId(id);
        }

        public Filme EditarFilme(Filme filme)
        {
            return _filmeRepository.EditarFilme(filme);
        }
    }
}
