using BlogAPI.Core.Domain.Entidades;
using FluentValidation;

namespace BlogAPI.Core.Domain.Validadores
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(obj => obj.Conteudo)
              .NotEmpty()
              .WithMessage("O Conteúdo do Comentário é de preenchimento obrigatório.");
        }
    }
}
