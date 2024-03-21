using Microsoft.AspNetCore.Mvc;
using TCDDBiletlemeAPI.Services;
using TCDDBiletlemeAPI.Models;


namespace TCDDBiletlemeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly MongoDBServices _mongoDBService;

    public TicketController(MongoDBServices mongoDBServices)
    {
        _mongoDBService = mongoDBServices;
    }

    [HttpGet]
    public async Task<List<Ticket>> Get(){
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Ticket todo){
        await _mongoDBService.CreateAsync(todo);
        return CreatedAtAction(nameof(Get), new { id= todo.Id }, todo);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> AddtoTodo(string id, [FromBody] string todoID){
        await _mongoDBService.AddtoTodoAsync(id, todoID);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id){
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }
}