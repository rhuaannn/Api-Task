using Api_Task_Application.UseCase.Task.CreatedTask;
using Api_Task_Application.UseCase.Task.DeleteTaskById;
using Api_Task_Application.UseCase.Task.GetTaskById;
using Api_Task_Application.UseCase.Task.UpdateTask;
using Api_Task_Communication.Request;
using Api_Task_Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api_Task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseTaskErroJson), StatusCodes.Status404NotFound)]
    public IActionResult Task([FromBody] RequestTaskJson request)
    {
        var response = new CreatedTaskUseCase().Execute(request);
        return Created(string.Empty, request);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IActionResult GetTaskById(int id)
    {
        var useCase = new GetTaskByIdUseCase();
        var response = useCase.Execute(id);

        return Ok(response);
    }
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseTaskErroJson), StatusCodes.Status400BadRequest)]

    public IActionResult UpdateTask(int id, [FromBody] RequestTaskJson request)
    {
        var useCase = new UpdateTaskUseCase();
        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public IActionResult DeleteTask(int id)
    {
        var useCase = new DeleteTaskByIdUseCase();
        useCase.Execute(id);

        return NoContent();
    }


}
