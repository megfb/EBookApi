using EBookApi.Application.Contracts.Persistence;
using FluentValidation;

namespace EBookApi.Application.Features.Authors.Create
{
    public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
    {

        private readonly IAuthorRepository _authorRepository;
        public CreateAuthorRequestValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name must not exceed 100 characters.");
            //.MustAsync(MustUniqueAuthorNameAsync).WithMessage("The name is found in DB");
            RuleFor(x => x.Biography)
                .NotEmpty()
                .WithMessage("Biography is required.")
                .MaximumLength(1000)
                .WithMessage("Biography must not exceed 1000 characters.");
        }


        //private async Task<bool> MustUniqueAuthorNameAsync(string name, CancellationToken cancellationToken)
        //{
        //    return !await _authorRepository.Where(x => x.Name == name).AnyAsync(cancellationToken);
        //}
    }
}
