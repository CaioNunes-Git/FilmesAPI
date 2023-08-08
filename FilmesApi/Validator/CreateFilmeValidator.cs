﻿using FilmesApi.Data.Dtos;
using FluentValidation;

namespace FilmesApi.Models.Validator
{
    public class CreateFilmeValidator : AbstractValidator<CreateFilmeDto>
    {
        public CreateFilmeValidator()
        {
            RuleFor(f => f.Titulo).NotEmpty()
                .WithMessage("Vai Cadastrar filme sem título é corno?");

            RuleFor(f => f.Genero).NotEmpty()
                .WithMessage("Informe um genere");
            
            RuleFor(f=>f.Duracao).LessThan(60)
                .WithMessage("Um curta isso aí");

            RuleFor(f=>f.Duracao).Equal(0)
                .WithMessage("Já acabou o filme?");

            /*RuleFor(f=>f.Duracao).NotNull()
                .WithMessage("Teu filme ta nulo meu patrão");*/
    }
}