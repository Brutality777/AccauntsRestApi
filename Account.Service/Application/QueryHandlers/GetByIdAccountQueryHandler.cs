using Account.Contracts.Commands;
using Account.Service.Domain.DataModels;
using Account.Service.Domain;
using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Contracts.Queries.Dtos;
using Account.Contracts.Queries;
using AutoMapper.QueryableExtensions;

namespace Account.Service.Application.QueryHandlers
{

    internal class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQuery, Result<StandartAccountInfo>>
    {
        private readonly IAccountDbContext _accDbContext;
        private readonly IMapper _mapper;
        public GetByIdAccountQueryHandler(IAccountDbContext accDbContext, IMapper mapper)
        {
            _accDbContext = accDbContext;
            _mapper = mapper;
        }

        public async Task<Result<StandartAccountInfo>> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
        {
            var acc =_accDbContext.Accounts.Where(x => x.Id == request.id).ProjectTo<StandartAccountInfo>(_mapper.ConfigurationProvider).FirstOrDefault();
            if (acc == null)
            {
                return Result.Fail("User with this id does not exists");
            }

            return Result.Ok(acc);

        }
    }
}
