﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateFilmeDto : BaseDto
    {
        
        [Required(ErrorMessage = "O titulo do filme é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Gênero do filme é obrigatório")]
        [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres excedido")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A duração do filme é obrigatória")]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
