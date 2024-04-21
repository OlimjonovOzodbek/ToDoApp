﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.UseCases.Commands;
using Todo.Application.UseCases.Queries;
using Todo.Domain.Entities;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<Issue> Create(CreateIssueCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<IEnumerable<Issue>> GetAll()
        {
            return await _mediator.Send(new GetAllIssueQuery());
        }
        [HttpGet("{id}")]
        public async Task<Issue> GetById(Guid id)
        {
            return await _mediator.Send(new GetByIdIssueQuery() { id = id });
        }
        [HttpDelete("{id}")]
        public async Task<Issue> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteIssueCommand() { Id = id });
        }
        [HttpPut]
        public async Task<Issue> Update(UpdateIssueCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}

