using Account.Contracts.Queries.Dtos;
using FluentResults;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Contracts.Commands
{
    public class UpdateAccountNameCommand : IRequest<Result<StandartAccountInfo>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateAccountNameCommandValidator : AbstractValidator<UpdateAccountNameCommand>
    {
        public UpdateAccountNameCommandValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty")
                .MaximumLength(127)
                .WithMessage("Name must be lesst than 127 characters");

            RuleFor(x => x.Id).NotEmpty().WithMessage("You must pass the id").GreaterThanOrEqualTo(1).WithMessage("Id must be greater than 0");

        }
    }
}
