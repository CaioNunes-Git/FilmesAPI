using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Repository
{
    public interface IFilmeRepository
    {
         IEnumerable<Filme> ListarTodos(int skip = 0, int take = 10);

         Filme AdicionarFilme(Filme filme);

         Filme EditarFilme(int id, UpdateFilmeDto filme);

         void ApagarFilme(int id);

         Filme BuscarFilmePorId(int id);

    }
}
