using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Service.Interfaces
{
    public interface IFilmeService
    {
        IEnumerable<Filme> ListarTodos(int skip,int take);

        Filme AdicionarFilme(Filme filme);

        Filme EditarFilme(Filme filme);

        void ApagarFilme(int id);

        Filme BuscarFilmePorId(int id);

    }
}
