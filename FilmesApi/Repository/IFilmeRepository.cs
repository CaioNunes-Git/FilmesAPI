using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Repository
{
    public interface IFilmeRepository
    {
         IEnumerable<Filme> ListarTodos(int skip = 0, int take = 10);

         Filme AdicionarFilme(Filme filme);

         Filme EditarFilme(Filme filme);

         void ApagarFilme(Filme filme);

         Filme BuscarFilmePorId(int id);

    }
}
