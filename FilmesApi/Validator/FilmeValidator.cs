using FilmesApi.Data.Dtos;
using FilmesApi.Repository;
using FluentValidation;
using FluentValidation.Validators;

namespace FilmesApi.Models.Validator
{
    public class FilmeValidator : AbstractValidator<UpdateFilmeDto>
    {
        public FilmeValidator(IFilmeRepository filmeRepository) 
        {

            RuleFor(f => f.Titulo).NotEmpty()
                .WithMessage("Vai Cadastrar filme sem título é corno?");

            RuleFor(f => f.Titulo).MaximumLength(70)
                .WithMessage("Maior título do mundo?");

            RuleFor(f => f.Genero).NotEmpty()
                .WithMessage("Informe um genere");

            RuleFor(f => f.Genero).MaximumLength(50)
                .WithMessage("Coleres chega! Passou de 50 a API dorme!");
            
            RuleFor(f=>f.Duracao).GreaterThan(60)
                .WithMessage("Um curta isso aí");

            RuleFor(f=>f.Duracao).NotEqual(0)
                .WithMessage("Já acabou o filme?");

            RuleFor(f => f).NotNull()
                .WithMessage("Tome vergonha e me mande um filme que não seja nulo");

            RuleFor(f => f.Id).NotEqual(0)
                .WithMessage("Id inválido");

            RuleFor(f => f.Id).SetValidator(new IdFilmeExiste(filmeRepository))
                .WithMessage("O id pesquisado não pertence a nenhum filme cadastrado");

        }

        private sealed class IdFilmeExiste: PropertyValidator<UpdateFilmeDto, int>
        {
            private readonly IFilmeRepository _filmeRepository;

            public override string Name => "Validador para buscar se o filme pesquisado existe";

            protected override string GetDefaultMessageTemplate(string errorCode)
                => "É necessário passar um id válido";

            public IdFilmeExiste(IFilmeRepository filmeRepository) : base() {
                _filmeRepository = filmeRepository;
            }

            public override bool IsValid(ValidationContext<UpdateFilmeDto> context, int id)
            {
                Filme filme = _filmeRepository.BuscarFilmePorId(id);
                return filme != null ? true : false;
            }
            

        }
    }
}
