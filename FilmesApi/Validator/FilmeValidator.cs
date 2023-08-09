using FilmesApi.Data.Dtos;
using FluentValidation;

namespace FilmesApi.Models.Validator
{
    public class FilmeValidator : AbstractValidator<UpdateFilmeDto>
    {
        public FilmeValidator() 
        {
            RuleFor(f => f.Titulo).NotEmpty()
                .WithMessage("Vai Cadastrar filme sem título é corno?");

            RuleFor(f => f.Genero).NotEmpty()
                .WithMessage("Informe um genere");
            
            RuleFor(f=>f.Duracao).LessThan(60)
                .WithMessage("Um curta isso aí");

            RuleFor(f=>f.Duracao).Equal(0)
                .WithMessage("Já acabou o filme?");

            RuleFor(f => f).NotNull()
                .WithMessage("Tome vergonha e me mande um filme que não seja nulo");
        }

    }
}
