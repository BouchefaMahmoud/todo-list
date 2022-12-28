using Application.Services.UseCases.AddTodoList;
using Application.Services.UseCases.GetAllTodoLists;
using Application.Services.UseCases.GetTodoListById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoListController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<TodoListController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> Get()
        {
            var result = await _mediator.Send(new GetAllTodoListsRequest());
            return Ok(result);
        }

        // GET api/<TodoListController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetTodoListByIdRequest(id));
            return Ok(result);
        }

        // POST api/<TodoListController>
        [HttpPost()]
        public async Task<ActionResult<Guid>> Post([FromBody] AddTodoListCommand addTodoListCommand)
        {
            return await _mediator.Send(addTodoListCommand);  
        }

        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
