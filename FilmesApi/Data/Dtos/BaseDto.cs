﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class BaseDto
    {
        
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Genero { get; set; }

        public int Duracao { get; set; }
    }
}
