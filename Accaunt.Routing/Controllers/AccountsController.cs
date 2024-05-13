using Account.Contracts.Commands;
using Account.Contracts.Queries;
using Account.Contracts.Queries.Dtos;
using Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Routing.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    [SwaggerTag("Accounts managment")]
    public class AccountsController : ControllerBase
    {
        private IMediator _mediator;
        public AccountsController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpPost("AddAccount")]
        [SwaggerOperation(Summary = "Create an account",Description = "Registarte an account using name and checks everything to be good",OperationId = "AddAccount")]
        [SwaggerResponse(StatusCodes.Status200OK,"Account is created succefully",typeof(int))]
        public async Task<IResult> AddAccount([FromBody] AddAccountCommand dto)
        {
            var result = await _mediator.Send(dto);
            if (!result.IsSuccess)
            {
                return result.ToProblemDetails();
            }
            return Results.Ok(result.Value);
        }

        [HttpGet("GetAccountById")]
        [SwaggerOperation(Summary = "Get an account by its id", Description = "Gets standart info about account by its id", OperationId = "GetAccountById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Found account", typeof(StandartAccountInfo))]
        public async Task<IResult> GetAccountById([FromQuery] GetByIdAccountQuery dto)
        {
            var result = await _mediator.Send(dto);
            if (!result.IsSuccess)
            {
                return result.ToProblemDetails();
            }
            return Results.Ok(result.Value);
        }

        [HttpPatch("ChangeAccountNameById")]
        [SwaggerOperation(Summary = "Change account name", Description = "Change account name by its id", OperationId = "ChangeAccountNameById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Changed account name succefully", typeof(StandartAccountInfo))]
        public async Task<IResult> ChangeAccountNameById([FromBody] UpdateAccountNameCommand dto)
        {
            var result = await _mediator.Send(dto);
            if (!result.IsSuccess)
            {
                return result.ToProblemDetails();
            }
            return Results.Ok(result.Value);
        }
    }
}
