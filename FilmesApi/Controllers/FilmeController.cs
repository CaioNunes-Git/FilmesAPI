﻿using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Service;
using FilmesApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        
        private readonly IFilmeService _filmeService;
        private IMapper _mapper;

        
        public FilmeController(IFilmeService filmeService, IMapper mapper)
        {
            _filmeService = filmeService;
            _mapper = mapper; 
        }

        [HttpGet]
        public IEnumerable<Filme> ListarTodos([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _filmeService.ListarTodos(skip,take);
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _filmeService.AdicionarFilme(_mapper.Map<Filme>(filmeDto));
            return CreatedAtAction(nameof(BuscarFilmePorId), new { filme.Id }, filmeDto);
        }

        [HttpPut]
        public IActionResult EditarFilme([FromBody] UpdateFilmeDto filmeDto)
        {
            _filmeService.EditarFilme(_mapper.Map<Filme>(filmeDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ApagarFilme(int id)
        {
            _filmeService.ApagarFilme(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            Filme filme = _filmeService.BuscarFilmePorId(id);
            return Ok(filme);
        }
    }
}
