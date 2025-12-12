using BlogAPI.Core.Domain.Entidades;
using FluentValidation;

namespace BlogAPI.Core.Domain.Validadores
{
    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator()
        {
            RuleFor(obj => obj.Titulo)
              .NotEmpty()
              .WithMessage("O Título do Blog é de preenchimento obrigatório.");

            RuleFor(obj => obj.Titulo)
              .MinimumLength(3)
              .WithMessage("O Título do Blog precisa ser maior que 3 caracteres.");

            RuleFor(obj => obj.Conteudo)
              .NotEmpty()
              .WithMessage("O Conteúdo do Blog é de preenchimento obrigatório.");

            RuleFor(obj => obj.Conteudo)
              .MinimumLength(10)
              .WithMessage("O Conteúdo do Blog precisa ser maior que 10 caracteres.");

        }
    }
}
