using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;
using ToDoListAPI.ResponseDto;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToDoController : ControllerBase
    {
        private readonly ITaskToDoService _taskToDoService;
        public TaskToDoController(ITaskToDoService taskToDoService)
        {
            _taskToDoService = taskToDoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskToDoResponse>>> GetTasksToDo()
        {
            return Ok(await _taskToDoService.GetTasksToDo());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskToDoResponse>> GetTaskToDo(int id)
        {
            var result = await _taskToDoService.GetTaskToDo(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskToDo?>>> AddTaskToDo(TaskToDo task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            var createdTaskToDo = await _taskToDoService.AddTaskToDo(task);

            return CreatedAtAction(nameof(GetTaskToDo),
                new { Id = createdTaskToDo.TaskToDoId}, createdTaskToDo);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TaskToDo?>> UpdateTaskToDo(int id, TaskToDo request)
        { 
            if (id != request.TaskToDoId)
            {
                return BadRequest("Task Id mismatch");
            }

            var taskToDoToUpdateId = await _taskToDoService.GetTaskToDo(request.TaskToDoId);

            if (taskToDoToUpdateId == null)
            {
                return NotFound($"TaskToDo with Id = {request.TaskToDoId} not found");
            }

            return await _taskToDoService.UpdateTaskToDo(request);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TaskToDo?>> Delete(int id)
        {
            var taskToDoToDelete = await _taskToDoService.GetTaskToDo(id);

            if (taskToDoToDelete == null)
            {
                return NotFound($"TaskToDo with Id = {id} not found");
            }

            return await _taskToDoService.DeleteTaskToDo(id);
        }

        [HttpPut]
        [Route("{taskId}/assign/user/{userId}")]
        public async Task<ActionResult<UserResponse>> AssignUserToTask([FromRoute] int taskId, [FromRoute] int userId)
        {
            await _taskToDoService.AssignUserToTask(taskId, userId);
            return NoContent();
        }

    }
}
