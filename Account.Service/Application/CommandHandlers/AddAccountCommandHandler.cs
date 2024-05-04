using Account.Contracts.Commands;
using Account.Service.Domain;
using Account.Service.Domain.DataModels;
using AutoMapper;
using FluentResults;
using MediatR;

namespace Account.Service.Application.CommandHandlers
{
    internal class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, Result<int>>
    {
        private readonly IAccountDbContext _accDbContext;
        private readonly IMapper _mapper;
        public AddAccountCommandHandler(IAccountDbContext accDbContext,IMapper mapper)
        {
            _accDbContext = accDbContext;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var acc = _accDbContext.Accounts.FirstOrDefault(x => x.Name == request.Name);
            if (acc != null)
            {
                return Result.Fail("User with this name already exists");
            }
            var accountDataModel = _mapper.Map<AccountDataModel>(request);
            await _accDbContext.Accounts.AddAsync(accountDataModel);
            await _accDbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok(accountDataModel.Id);
        }
    }
}
