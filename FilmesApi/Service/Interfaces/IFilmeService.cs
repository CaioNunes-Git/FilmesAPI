using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Service.Interfaces
{
    public interface IFilmeService
    {
        public IEnumerable<Filme> ListarTodos(int skip,int take);

        public Filme AdicionarFilme(Filme filme);

        public Filme EditarFilme(int id, Filme filme);

        public IActionResult ApagarFilme(int id);

        public Filme BuscarFilmePorId(int id);

    }
}
