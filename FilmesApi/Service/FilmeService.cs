using FilmesApi.Data;
using FilmesApi.Models;
using FilmesApi.Repository;
using FilmesApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


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
            if (filme.Id == 0) throw new Exception("O Id do teu filme ta zerado rapaz");
            if (filme.Titulo == null) throw new ArgumentNullException("Vai Cadastrar filme sem título é corno?");
            if (filme.Genero == null) throw new ArgumentNullException("Informe um genere");
            if (filme.Duracao == 0) throw new Exception("Já acabou o filme?");
            return _filmeRepository.AdicionarFilme(filme);
        }

        public void ApagarFilme(int id)
        {
            if (id == 0 )
            {
                
            }
            _filmeRepository.ApagarFilme(id);
        }

        public Filme BuscarFilmePorId(int id)
        {
            if (id == 0) throw new ArgumentNullException("O Id do teu filme ta zerado rapaz");
            return _filmeRepository.BuscarFilmePorId(id);
        }

        public Filme EditarFilme(int id, Filme filme)
        {
            if (filme == null) throw new ArgumentNullException("Teu filme ta nulo meu patrão");
            if (filme.Id == 0) throw new ArgumentNullException("O Id do teu filme ta zerado rapaz");
            if (filme.Titulo == null) throw new ArgumentNullException("Vai Cadastrar filme sem título é corno?");
            if (filme.Genero == null) throw new ArgumentNullException("Informe um genere");
            if (filme.Duracao == 0) throw new ArgumentNullException("Já acabou o filme?");
            return _filmeRepository.BuscarFilmePorId(id);
        }
    }
}
