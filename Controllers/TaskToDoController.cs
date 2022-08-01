using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;
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
        public async Task<ActionResult<List<TaskToDoDTO>>> GetTasksToDo()
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
        public async Task<ActionResult<List<TaskToDoDTO>>> AddTaskToDo(TaskToDoDTO task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            var createdTaskToDo = await _taskToDoService.AddTaskToDo(task);

            return CreatedAtAction(nameof(GetTaskToDo),
                new { Id = createdTaskToDo.Id}, createdTaskToDo);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TaskToDoDTO?>> UpdateTaskToDo(int id, TaskToDoDTO request)
        { 
            if (id != request.Id)
            {
                return BadRequest("Task Id mismatch");
            }

            var taskToDoToUpdate = await _taskToDoService.GetTaskToDo(request.Id);

            if (taskToDoToUpdate == null)
            {
                return NotFound($"TaskToDo with Id = {request.Id} not found");
            }

            return await _taskToDoService.UpdateTaskToDo(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskToDoDTO?>> Delete(int id)
        {
            var taskToDoToDelete = await _taskToDoService.GetTaskToDo(id);

            if (taskToDoToDelete == null)
            {
                return NotFound($"TaskToDo with Id = {id} not found");
            }

            return await _taskToDoService.DeleteTaskToDo(id);
        }
    }
}
