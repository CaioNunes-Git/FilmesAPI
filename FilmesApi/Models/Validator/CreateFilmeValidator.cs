using FilmesApi.Data.Dtos;
using FluentValidation;

namespace FilmesApi.Models.Validator
{
    public class CreateFilmeValidator : AbstractValidator<CreateFilmeDto>
    {
        public CreateFilmeValidator()
        {
            RuleFor(f => f.Titulo)
            .NotEmpty()
            .WithMessage("Vai Cadastrar filme sem título é corno?");
        }
    }
}
