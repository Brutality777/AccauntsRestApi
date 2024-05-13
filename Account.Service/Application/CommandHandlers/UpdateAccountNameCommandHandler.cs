using Account.Contracts.Commands;
using Account.Contracts.Queries.Dtos;
using Account.Service.Domain;
using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Application.CommandHandlers
{
    internal class UpdateAccountNameCommandHandler : IRequestHandler<UpdateAccountNameCommand, Result<StandartAccountInfo>>
    {
        private readonly IAccountDbContext _accDbContext;
        private readonly IMapper _mapper;
        public UpdateAccountNameCommandHandler(IAccountDbContext accDbContext, IMapper mapper)
        {
            _accDbContext = accDbContext;
            _mapper = mapper;
        }

        public async Task<Result<StandartAccountInfo>> Handle(UpdateAccountNameCommand request, CancellationToken cancellationToken)
        {
            var acc = await _accDbContext.Accounts.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (acc == null)
            {
                return Result.Fail("User with this id do not exists");
            }
            acc.Name = request.Name;
            await _accDbContext.SaveChangesAsync(cancellationToken);
            return Result.Ok(_mapper.Map<StandartAccountInfo>(acc));

        }
    }
}
