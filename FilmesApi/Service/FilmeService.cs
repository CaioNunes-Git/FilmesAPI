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
            if (filme == null) throw new ArgumentNullException("Teu filme ta nulo meu patrão");
            if (filme.Titulo == null) throw new ArgumentNullException("Vai Cadastrar filme sem título é corno?");
            if (filme.Genero == null) throw new ArgumentNullException("Informe um genere");
            if (filme.Duracao == 0) throw new Exception("Já acabou o filme?");
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
            if (filme == null) throw new ArgumentNullException("Teu filme ta nulo meu patrão");
            if (filme.Titulo == null) throw new ArgumentNullException("Vai Cadastrar filme sem título é corno?");
            if (filme.Genero == null) throw new ArgumentNullException("Informe um genere");
            if (filme.Duracao == 0) throw new ArgumentNullException("Já acabou o filme?");
           
            var filmeV = _filmeRepository.BuscarFilmePorId(filme.Id);
            if (filmeV == null) throw new KeyNotFoundException("F");

            return _filmeRepository.EditarFilme(filme);
        }
    }
}
