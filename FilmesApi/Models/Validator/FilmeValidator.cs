using FilmesApi.Data.Dtos;
using FluentValidation;

namespace FilmesApi.Models.Validator
{
    public class FilmeValidator : AbstractValidator<UpdateFilmeDto>
    {
        public FilmeValidator() 
        {

            RuleFor(f => f.Titulo)
                .NotEmpty()
                    .WithMessage("Vai Cadastrar filme sem título é corno?");
        }

    }
}
