using Account.Contracts.Queries.Dtos;
using FluentResults;
using FluentValidation;
using MediatR;

namespace Account.Contracts.Queries
{
    public class GetByIdAccountQuery : IRequest<Result<StandartAccountInfo>>
    {
        public int id;
    }

    public class GetByIdAccountQueryValidator : AbstractValidator<GetByIdAccountQuery>
    {
        public GetByIdAccountQueryValidator()
        {
            RuleFor(x => x.id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0).WithMessage("Id must be bigger than 0");
        }
    }
}

