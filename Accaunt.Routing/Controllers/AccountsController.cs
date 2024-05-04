﻿using Account.Contracts.Commands;
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
        [HttpPost]
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
    }
}