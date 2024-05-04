using FluentResults;
using FluentValidation;
using MediatR;

namespace Account.Contracts.Commands
{
    public class AddAccountCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
    }

    public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
    {
        public AddAccountCommandValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty")
                .MaximumLength(127)
                .WithMessage("Name must be lesst than 127 characters");
        }
    }
}
